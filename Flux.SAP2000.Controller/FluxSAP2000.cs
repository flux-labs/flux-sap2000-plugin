using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using Flux.SDK.Types;
using Flux.SDK.Logger;
using Flux.SDK;
using Flux.SDK.DataTableAPI;
using System.Text;
using Flux.SDK.Serialization;
using Flux.SAP2000.Interop;
using System.Configuration;
using SAP2000v18;
using Flux.SAP2000.Converters;
using System.Threading.Tasks;

namespace Flux.SAP2000.Controller
{


    public partial class FluxSAP2000 : Form
    {
        IFluxSDK _sdk;
        IFluxLogger _log;
        cOAPI _activeSAP2000model;
        //ISAP2000Command _command;

        public FluxSAP2000()
        {
            InitializeComponent();

            _log = LogHelper.GetLogger("Flux.GSAPlugin");
            _log.Info("Loading Flux SAP2000 Controller");

            //App settings

            //Make sure assocaited file App.config contains your unique clientSecret
            //This functions wil retrieve this information from the file automatically
            //Also ensure your Flux.config file is untracked and not synced with GitHub
            //Visit https://flux.io/developer/apps to generate clientID's
            string clientID = ConfigurationManager.AppSettings["clientID"];
            string clientVersion = ConfigurationManager.AppSettings["clientVersion"];

            if (clientID == null || clientID.Equals(""))
            {
                _log.Info("No FluxClientID was found. Check App.config.");

                throw new Exception(
                    "A FluxClientID was not specified, or could not be found. " +
                    "Check your app settings.");
            }

            //set up the sdk wrapper
            _sdk = SDKProvider.InitSDK(clientID, clientVersion);
            //auto login attempt
            Login();
           

        }


        //Not sure what this does yet...need to ask Karl
        private void FluxSAP2000_Load(object sender, EventArgs e)
        {
            if (_sdk.CurrentUser == null)
            {
                _log.Info("No Flux user is currently logged in.");
                //Login();
            }
            else
            {
                _log.Info("Flux user {0} is logged in.", _sdk.CurrentUser.Email);
                InitWithUser(_sdk.CurrentUser);
            }
        }

        //Click event - log-in to Flux
        private void mnuLogIn_Click(object sender, EventArgs e)
        {
            Login();
        }

        //Click event - log-out of Flux
        private void mnuLogOut_Click(object sender, EventArgs e)
        {
            Logout();
        }

        private void cboProjectsTo_DataSourceChanged(object sender, EventArgs e)
        {
            cboKeysTo.DataSource = null;
        }

        private void cboProjectsFrom_DataSourceChanged(object sender, EventArgs e)
        {
            cboKeysFrom.DataSource = null;
        }

        private void cboProjectsTo_SelectedIndexChanged(Object sender, EventArgs e)
        {
            BindKeys(cboKeysTo, (Project)cboProjectsTo.SelectedItem);
        }

        private void cboProjectsFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindKeys(cboKeysFrom, (Project)cboProjectsFrom.SelectedItem);
        }

        private void btnReceive_Click(object sender, EventArgs e)
        {
            if (_activeSAP2000model == null)
            {
                MessageBox.Show("A SAP2000 file must be open to receive data from Flux. " +
                    "Use File > Open SAP2000 Model...");
                return;
            }

            if (cboKeysFrom == null)
            {
                MessageBox.Show("Select a key to receive from.");
            }
            else
                ReceiveFromFlux();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (_activeSAP2000model == null)
            {
                MessageBox.Show("A SAP2000 file must be open to send data to Flux. " +
                    "Use File > Open SAP2000 Model...");
                return;
            }
            //Remove code below for offline debugging
            /*
            if (cboKeysTo.SelectedItem == null)
            {
                MessageBox.Show("Select a key before sending.");
            }
            */
            else
                SendToFlux();
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mnuOpen_Click(object sender, EventArgs e)
        {
            _activeSAP2000model = Flux.SAP2000.Interop.SAP2000.SAP2000attach();
            Console.WriteLine("Attached");
            BindGroups();
            //dlgOpenFile.ShowDialog();
        }

        private void mnuDetach_Click(object sender, EventArgs e)
        {
            _activeSAP2000model = null;
            Console.WriteLine("Deattached");
            //dlgOpenFile.ShowDialog();
        }

        private void dlgOpenFile_FileOk(object sender, CancelEventArgs e)
        {
            //_command = Flux.SAP2000.Interop.SAP2000.createCommand(dlgOpenFile.FileName);
            Console.WriteLine("open file yo");
            BindGroups();
            //UpdateMenuOptions();
        }




        private string StatusMessage
        {
            get
            {
                return staMain.Items[0].Text;
            }
            set
            {
                staMain.Items[0].Text = value;
            }
        }

        private void ReceiveFromFlux()
        {
            try
            {
                btnReceive.Enabled = false;
                btnReceive.Text = "Receiving...";

                CellInfo cell = (CellInfo)cboKeysFrom.SelectedItem;
                Project project = (Project)cboProjectsFrom.SelectedItem;
                //FluxReceiver receiver = new FluxReceiver(project, cell, chkAutoAnalyze.Checked);
                //receiver.Receive(_command);
            }
            catch (Exception e)
            {
                _log.Warn("Exception receiving data to flux: {0}", e.Message);
                MessageBox.Show("Error receiving data from key :(");
            }
            finally
            {
                btnReceive.Enabled = true;
                btnReceive.Text = "Receive";
            }
        }

        private void SendToFlux()
        {
            try
            {
                btnSend.Enabled = false;
                btnSend.Text = "Sending...";

                CellInfo cell = (CellInfo)cboKeysTo.SelectedItem;
                Project project = (Project)cboProjectsTo.SelectedItem;

                //Default to extract all elements in case groups are not populated in drop down
                string groupName = null;

                //line of code below is where we will select the SAP2000 group to send to Flux
                groupName = (string)cboLists.SelectedItem;

                //Make call to extract all 1d SAP2000 elements and associated forces
                // ! currently investigating extracting 1d elements by name or by group...



                List<SAP20001dElement> elements1d = Interop.SAP2000.SAP2000Get1dElements(_activeSAP2000model, groupName);


                //Send this data to the selected Flux Project and Data Key (known as a Cell by the SDK)
                project.DataTable.SetCell(cell, elements1d);
                

                Console.WriteLine(elements1d.Count);
                //debug
                for (var k = 0; k < elements1d.Count; k++)
                {
                    Console.WriteLine(elements1d[k].Forces.V2[0]);
                }
            }
            catch (Exception e)
            {
                _log.Warn("Exception sending data to flux: {0}", e.Message);
                MessageBox.Show("Error sending data to key :(");
            }
            finally
            {
                btnSend.Enabled = true;
                btnSend.Text = "Send";
            }
        }

        private void Login()
        {
            try
            {
                _log.Debug("Attempting to log in to Flux.");

                _sdk.OnUserLogin += flux_OnUserLogin;

                //Make sure assocaited file App.config contains your unique clientSecret
                _sdk.Login(
                    ConfigurationManager.AppSettings["clientSecret"],
                    ConfigurationManager.AppSettings["redirectUrl"]
                    );

            }
            catch (Flux.SDK.Exceptions.AuthorizationFailedException)
            {
                //_log.Warn(e.Message);
                //_log.Debug(e.StackTrace);

                MessageBox.Show(
                    "Error connecting to Flux. Please try again later :(", "Flux Login Error");
            }
        }

        private void flux_OnUserLogin(User user)
        {
            if (_sdk.CurrentUser != null)
                InitWithUser(user);
        }

        //log-out sequence
        private void Logout()
        {
            if (_sdk.CurrentUser != null)
            {
                _sdk.Logout();
                _log.Info("User has logged out.");

                //clear the list of projects/keys since the user is no longer authenticated
                cboProjectsFrom.DataSource = null;
                cboProjectsTo.DataSource = null;

                UpdateMenuOptions();
            }
        }


        private void InitWithUser(User user)
        {
            /*
            InitWithUser method might be called by a worker thread, which does not have access
            to controls created on the ui thread
            */
            if (cboProjectsFrom.InvokeRequired)
            {
                cboProjectsFrom.Invoke(new Action<User>(InitWithUser), user);
                return;
            }

            _log.Debug("Initializing from user {0}...", user.Email);

            if (user == null)
                throw new Exception("Cannot init without being logged in. Fix It.");

            _log.Debug("Loading projects for user {0}...", user.Email);

            if (user.UserProjects != null)
            {
                _log.Debug("Loaded {0} projects.", user.UserProjects.Count);

                cboProjectsTo.DisplayMember = "name";
                cboProjectsTo.ValueMember = "id";
                cboProjectsTo.DataSource = new List<Project>(user.UserProjects);
                cboProjectsTo.SelectedItem = null;

                cboProjectsFrom.DisplayMember = "name";
                cboProjectsFrom.ValueMember = "id";
                cboProjectsFrom.DataSource = new List<Project>(user.UserProjects);
                cboProjectsFrom.SelectedItem = null;
            }

            UpdateMenuOptions();
        }

        private void BindKeys(ComboBox cboKeys, Project project)
        {
            if (project != null)
            {
                _log.Debug("Project changed to {0} ({1})...", project.Name, project.Id);

                List<CellInfo> cells = project.DataTable.Cells;

                cboKeys.DisplayMember = "ClientMetadata.Label";
                cboKeys.ValueMember = "CellId";
                cboKeys.DataSource = cells;
            }
            else
            {
                _log.Debug("No project is selected.");
                cboKeys.DataSource = null;
            }
        }

        //Populate the SAP2000 model group drop down list
        private void BindGroups()
        {

            List<string> GroupNames = Interop.SAP2000.getAllGroupNames(_activeSAP2000model);
            if (GroupNames != null)
            {
                cboLists.DisplayMember = "Name";
                cboLists.ValueMember = "Ref";
                cboLists.DataSource = GroupNames;
            }
        }


        private void ComboBoxFormat(object sender, ListControlConvertEventArgs e)
        {
            e.Value = ((CellInfo)e.ListItem).ClientMetadata.Label;
        }

        private void UpdateMenuOptions()
        {
            if (_sdk.CurrentUser == null)
            {
                mnuLogIn.Enabled = true;
                mnuLogOut.Enabled = false;
                //tabFlux.Enabled = false;
                mnuLogOut.Text = "Log Out";

                this.StatusMessage = "Log in to Flux";
            }
            else
            {
                mnuLogIn.Enabled = false;
                mnuLogOut.Enabled = true;
                //tabFlux.Enabled = true;
                mnuLogOut.Text = String.Format("Log out '{0}'", _sdk.CurrentUser.Email);

                if (_activeSAP2000model == null)
                    this.StatusMessage = "SAP2000 model has not been loaded.";
                //else
                //this.StatusMessage = String.Format(
                //    "Loaded model: {0}", _command.ModelFilePath);
            }
        }

        private void clearNodesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (_command != null)
            //    _command.RemoveAllEntities();
        }

        private void testNodeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void FluxSAP2000_Load_1(object sender, EventArgs e)
        {

        }

        private void cboLists_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string groupName = cboLists.SelectedValue.ToString();
            //For some reason the next function does not return correctly for list name "ALL"...need to fix
            int number = Interop.SAP2000.countObjectsInGroup(_activeSAP2000model, groupName);
            label6.Text = number + " elements will be sent to Flux";
        }
        /*
private void cboLists_SelectedIndexChanged(object sender, EventArgs e)
{
//Count objects in a group to update UI message
int numberInGroup = 0;
int[] types = new int[0];
string[] objNames = new string[0];

_activeSAP2000model.SapModel.GroupDef.GetAssignments(cboLists.SelectedItem.ToString(), ref numberInGroup, ref types, ref objNames);
label6.Text = numberInGroup + " elements will be sent to Flux";

}*/

    }
}


