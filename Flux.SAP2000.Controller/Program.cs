using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Flux.SDK.DataTableAPI.DatatableTypes;
using Flux.SDK.Types;
using Flux.SDK;
using Flux.SDK.Serialization;
using Flux.SDK.Logger;
using Flux.SAP2000.Interop;
using Flux.SAP2000.Converters;
using Flux.SDK.DataTableAPI;
using System.Windows.Forms;
using Flux.SAP2000.Controller;

namespace Flux.SDK.SAP2000
{

    public class Program
    {
      

        private static IFluxSDK _sdk;
        private static IFluxLogger _log;

        static void Main(string[] args)
        {
            Application.Run(new FluxSAP2000());
            Console.WriteLine("Flux SDK Sample Application. Version {0}", 
                System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString());
            
            #region Create an instance of Flux SDK 
            //Console.WriteLine("Getting Flux SDK");

            //replace this with your personalized Flux client ID
            //var clientId = "";
            //var clientVersion = "dev";
            //_sdk = SDKProvider.InitSDK(clientId, clientVersion);

            //auth token may be cached, so we reset it by logging out before demonstrating login
            //if (_sdk.CurrentUser != null)
            //    _sdk.Logout();

            //you can set the input string for logger to your own app's namespace
            //_log = LogHelper.GetLogger("Flux.SDK.TestApp");

            #endregion

            #region Login to Flux
            
            //login event handler will be called after login has successfully completed
            _sdk.OnUserLogin += Flux_OnUserLogin;

            //logout event handler will be called after logging out
            _sdk.OnUserLogout += Flux_OnUserLogout;

            
            try
            {

                //Login to Flux using Open ID connect authorization flow using

                //-Your client secret, provided by Flux
                //-A URL to return to after authorization has finished

                _sdk.Login(
                    "c287b8e9-bac5-4502-b2ae-c7f83dfd9c09",
                    "https://community.flux.io/articles/2293/sap2000-plugin.html");

            }
            catch (Flux.SDK.Exceptions.AuthorizationFailedException)
            {
                Console.WriteLine("login failed");
            }
            
            #endregion

            //waits for user input before closing the console
            Console.ReadLine();
        }

    
        static void Flux_OnUserLogin(User user)
        {
            Console.WriteLine("Logged in as '{0}'", user.FullName);

            //remove: var SAPinstance = new Flux.SAP2000.Interop.SAP2000();
            
            //SAPinstance.SAP2000function();
            //string[] blank = new string[0];
            //string nodes = null;
            //nodes = SAPinstance.SAP2000example(blank);

            //List<FluxPoint> nodes = null;
            List<SAP20001dElement> elements1d = null;
            //nodes = SAPinstance.SAP2000GetNodes();
            //remove: elements1d = SAPinstance.SAP2000Get1dElements();
            //SAP2000 nodes now stored in 'nodes' - need to convert to JSON

            
            
            Project project = new Project();
            
            List<Project> projects = new List<Project>();
            user.UpdateProjects();
            // HARDCODE TO SPECIFIC PROJECT FOR DEVELOPMENT
            foreach (Project q in user.UserProjects)
                {if (q.Id == "aVZJo67dqdQj249W2") { project = q; } }
            Console.WriteLine(project.Name);
            //project.DataTable.GetCell()
            

        
        
            //        #region Get projects for the currently logged in user

            //        Console.WriteLine("Reading projects that can be accesssed by '{0}'...", user.FullName);

            //        //loop over projects available to the logged in user
            //        user.UpdateProjects();
            //        foreach(Project p in user.UserProjects)
            //            Console.WriteLine("> Project (id={0}): '{1}' ", p.Id, p.Name);

            //#endregion



            //#region Get cells (aka keys) in the data table of the last project
            //Project project = user.UserProjects.Last();
            //        if (project != null)
            //        {
            //            Console.WriteLine("Listing available cells for project '{0}'...", project.Name);

            //            //Iterate through cells in the project's data table
            //            List<CellInfo> cells = project.DataTable.GetCells();
            //            foreach (CellInfo info in cells)
            //                Console.WriteLine("> Cell (id={0}) '{1}'", info.CellId, info.ClientMetadata.Label);
            //        }
            //        #endregion

                    //#region Create a new project to use for the remainder of this script
                    //project = user.CreateNewProject("Test Project Created by Flux SDK");

                    //Console.WriteLine("Created project '{0}'.", project.Name);
                    //#endregion

                    try
                    {
                        #region Register for notifications when the project's data table is modified 
                        project.DataTable.OnError += ErrorReceived;
                        project.DataTable.OnNotification += NotificationReceived;
                        project.DataTable.Subscribe(NotificationType.__ALL__);
               
                        #endregion

                        #region Create a new cell (aka key) in the project

                        Console.WriteLine("Trying to CREATE a new cell.");

                        //Give the new cell a label and description 
                        ClientMetadata meta = new ClientMetadata();
                        meta.Label = "SAP2000Test";
                        meta.Description = "This cell was created using the Flux SDK.";
                        meta.Locked = false;

                        //CellInfo created = project.DataTable.CreateCell("My test value", meta);
                        
                
                        //Console.WriteLine("New cell '{0}' was created with Id={1}.",
                        //    created.ClientMetadata.Label, created.CellId);

                        #endregion

                        //#region Get the cell's value

                        ////read the cell value              
                        //Console.WriteLine("Trying to GET value of the newly created cell.");

                        //Cell existingCell = project.DataTable.GetCell(created, true, true);

                        //Console.WriteLine("Cell '{0}' has value: '{1}'",
                        //    existingCell.Info.ClientMetadata.Label, existingCell.Value.AsString());

                        //#endregion

                        #region Set the cell's value

                        Console.WriteLine("Trying to SET value of the cell we created.");

                        //string updatedValue = convertToJson(nodes) ; //"This is an updated value";
                        //object updatedValue = elements1d;
                

                        //Console.WriteLine("Updating cell '{0}' to value: '{1}'",
                        //created.ClientMetadata.Label, updatedValue);

                try {
                    SerializationSettings settings = new SerializationSettings();
                    settings.EnableConvertersSupport = true;
                    

                    //string value = JsonConvert.SerializeObject (elements1d);

                    //double[] test = { 0 };
                    //var value = DataSerializer.Serialize<Double[]>(test, settings);

                    var value = DataSerializer.Serialize<SAP20001dElement[]>(elements1d.ToArray(), settings);
                    //System.Console.Write(value);
                    //System.Console.Write(value.GetType());
                    CellInfo created = project.DataTable.CreateCell(value, meta);

                    //project.DataTable.SetCell(created, value);
                }
                catch(Exception e)
                {
                    System.Console.Write(e.Message);
                }

                        //project.DataTable.SetCell(created, );

                ////verify that the cell was updated by getting the value
                //Cell verified = project.DataTable.GetCell(created, true, true);

                //Console.WriteLine("Cell '{0}' has value: '{1}'",
                //    verified.Info.ClientMetadata.Label, verified.Value.AsString());

                #endregion

                //#region Delete the cell we created

                //Console.WriteLine("Trying to DELETE value of the newly created cell.");

                //CellInfo deleted = project.DataTable.DeleteCell(created.CellId);

                //Console.WriteLine("Cell '{0}' was deleted.",
                //    deleted.ClientMetadata.Label);

                //#endregion
            }
                    catch (Exception e)
                    {
                        _log.Warn(e);
                    }
                    finally
                    {
                        //#region Delete the project we created for this script
                        //user.DeleteProject(project.Id);

                        //Console.WriteLine("Deleted project '{0}'", project.Name);
                        //#endregion
                    }

                }

            
        #region Flux SDK event handlers

        static void Flux_OnUserLogout()
        {
            Console.WriteLine("User has logged out.");
        }

        private static void NotificationReceived(object sender, NotificationEventArgs e)
        {
            Console.WriteLine("Notification for cell '{0}' has been received. Reason: {1}", 
                e.Notification.CellInfo.ClientMetadata.Label, e.Notification.CellEvent.Type);
        }

        private static void ErrorReceived(object sender, DataTableAPI.ErrorEventArgs e)
        {
            Console.WriteLine("Error notification: {0}",
                e.Error.Message);
        }
        #endregion
        
    }
}