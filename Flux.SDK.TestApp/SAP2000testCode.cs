using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;
//using Flux.SAP2000.Interop.Impl;
using SAP2000v18;

 

namespace Flux.SDK.SAP2000

{

    //SPECIFY SAP2000 SPECIFIC CLASSES FOR STORING API RETURNED DATA

    




    public class SAP2000elementForces
    {
        public string[] loadCase { get; set; }
        public double[] P { get; set; }
        public double[] V2 { get; set; }
        public double[] V3 { get; set; }
        public double[] T { get; set; }
        public double[] M2 { get; set; }
        public double[] M3 { get; set; }
    }



    class SAP2000testCode

{
        public void SAP2000function()
        {
            Console.WriteLine("I'm the SAP2000 module");
        }

        // PROVIDE COMMON METHOD FOR ATTACHING TO THE ACTIVE SAP2000 MODEL
        static cOAPI SAP2000attach() {

            cOAPI mySapObject = null;

            try
            {
                //get the active Sap2000 object
                mySapObject = (cOAPI)System.Runtime.InteropServices.Marshal.GetActiveObject("CSI.SAP2000.API.SapObject");
            }
            catch (Exception ex)
            {
                Console.WriteLine("No running instance of the program found or failed to attach.");
            }
            return mySapObject;

            // could also return units here? //\\//

        }

        // EXTRACT AND RETURN ALL NODES IN THE CURRENT MODEL
        public List<SAP2000Point> SAP2000GetNodes()
        {
            // attach tp current model
            cOAPI activeSAP2000model = SAP2000attach();
            var mySapModel = activeSAP2000model.SapModel;

            int ret;

            //get point names
            int NumOfPoints = 0;
            string[] PointNames = new string[0];
            ret = mySapModel.PointObj.GetNameList(ref NumOfPoints, ref PointNames);

            //get point coords

            //must created reference variables to accomodate response from SAP2000 API
            double X = new double();
            double Y = new double();
            double Z = new double();

            //create list for extracted points
            List<SAP2000Point> extractedPoints = new List<SAP2000Point>();

            //cycle through all points, create point class, populate with data from API call, add to point list
            for (int t = 0; t < NumOfPoints; t++)
            {
                ret = mySapModel.PointObj.GetCoordCartesian(PointNames[t], ref X, ref Y, ref Z);
                SAP2000Point newPoint = new SAP2000Point();
                double[] coords = new double[3];
                coords[0] = X;
                coords[1] = Y;
                coords[2] = Z;
                newPoint.point = coords;
                newPoint.id = PointNames[t];
                extractedPoints.Add(newPoint);
            }

            return extractedPoints;
        }

        // EXTRACT AND RETURN ALL 1D ELEMENTS IN THE CURRENT MODEL
        public List<SAP20001dElement> SAP2000Get1dElements()
        {
            List<SAP20001dElement> extracted1dElements = new List<SAP20001dElement>();

            cOAPI activeSAP2000model = SAP2000attach();
            var mySapModel = activeSAP2000model.SapModel;

            int NumOfLines = 0;
            string[] LineNames = new string[0];
            mySapModel.LineElm.GetNameList(ref NumOfLines, ref LineNames);
            
            
            string startPoint = "";
            string endPoint = "";
            double[] axial = new double[1];
            SAP2000elementForces forces = new SAP2000elementForces();

            for (int i = 0; i<NumOfLines;i++) {
                extracted1dElements.Add(new SAP20001dElement());
                mySapModel.LineElm.GetPoints(LineNames[i], ref startPoint, ref endPoint);
                forces = getFrameForces(mySapModel, LineNames[i]);
                extracted1dElements[i].forces = new forces();
                extracted1dElements[i].forces.P = forces.P;
                extracted1dElements[i].forces.V2 = forces.V2;
                extracted1dElements[i].forces.V3 = forces.V3;
                extracted1dElements[i].forces.T = forces.T;
                extracted1dElements[i].forces.M2 = forces.M2;
                extracted1dElements[i].forces.M3 = forces.M3;
                extracted1dElements[i].start = pointAsArray(mySapModel, startPoint);
                extracted1dElements[i].end = pointAsArray(mySapModel, endPoint);
                extracted1dElements[i].id = LineNames[i];
                extracted1dElements[i].loadCase = forces.loadCase;
            }

            return extracted1dElements;

        }

            private double[] pointAsArray(cSapModel mySapModel, string pointLabel)
            {
                //get point coords

                //must created reference variables to accomodate response from SAP2000 API
                double X = new double();
                double Y = new double();
                double Z = new double();
                int ret;

                ret = mySapModel.PointObj.GetCoordCartesian(pointLabel, ref X, ref Y, ref Z);
                //SAP2000Point newPoint = new SAP2000Point();
                double[] coords = new double[3];
                coords[0] = X;
                coords[1] = Y;
                coords[2] = Z;
                return coords;
            }

            private SAP2000elementForces getFrameForces(cSapModel mySapModel, string elementLabel) {
                
                //Create storage for API returned data
                SAP2000elementForces forces = new SAP2000elementForces();
            
                int ret = 0;            
                string[] loadCase = new string[1];
                double[] P = new double[1];
                P[0] = 0;
                double[] V2 = new double[1];
                V2[0] = 0;
                double[] V3 = new double[1];
                V3[0] = 0;
                double[] T = new double[1];
                T[0] = 0;
                double[] M2 = new double[1];
                M2[0] = 0;
                double[] M3 = new double[1];
                M3[0] = 0;
                double[] numberStations = new double[0];
                int numberResults = new int();
                numberResults = 0;
                double[] elmStation = new double[1];
                elmStation[0] = 0;
                string[] obj = new string[1];
                obj[0] = "";
                string[] elements = new string[1];
                elements[0] = "";
                double[] ObjSta = new double[1];
                ObjSta[0] = 0;
                double[] stepNum = new double[1];
                stepNum[0] = 0;
                string[] stepType = new string[1];
                stepType[0] = "";
                
                //Make API call to SAP2000

                //Extract element forces
                ret = mySapModel.Results.FrameForce(elementLabel, eItemTypeElm.Element, ref numberResults, ref obj, ref numberStations, ref elements, ref elmStation, ref loadCase, ref stepType, ref stepNum, ref P, ref V2, ref V3, ref T, ref M2, ref M3);

                //Set returned forces to the force container ready for return
                forces.P = P;
                forces.V2 = V2;
                forces.V3 = V3;
                forces.T = T;
                forces.M2 = M2;
                forces.M3 = M3;
                forces.loadCase = loadCase;
                
                //Debug output
                Console.WriteLine(elementLabel);
                Console.WriteLine("Did it run? = "+ret);
                Console.WriteLine("Number of results? = " + numberResults);
                //Console.WriteLine("Number of stations? = " + numberStations[0]);
                return forces;
            }


            //create list for extracted points
            //List<SAP2000Point> extractedPoints = new List<SAP2000Point>();


            }

            /*
            public string SAP2000example(string[] args)

        {



            //set the following flag to true to attach to an existing instance of the program

            //otherwise a new instance of the program will be started

            bool AttachToInstance = true;



            //full path to the program executable

            //set it to the installation folder

            string ProgramPath = "C:\\Program Files\\Computers and Structures\\SAP2000 18\\sap2000.exe";



            //full path to the model

            //set it to the desired path of your model

            string ModelDirectory = "C:\\CSiAPIexample";

            try
            {

                System.IO.Directory.CreateDirectory(ModelDirectory);

            }
            catch (Exception ex)
            {

                Console.WriteLine("Could not create directory: " + ModelDirectory);

            }



            string ModelName = "API_1-001.sdb";

            string ModelPath = ModelDirectory + System.IO.Path.DirectorySeparatorChar + ModelName;



            cOAPI mySapObject = null;

            if (AttachToInstance)
            {

                //attach to a running instance of Sap2000

                try
                {

                    //get the active Sap2000 object

                    mySapObject = (cOAPI)System.Runtime.InteropServices.Marshal.GetActiveObject("CSI.SAP2000.API.SapObject");



                }
                catch (Exception ex)
                {

                    Console.WriteLine("No running instance of the program found or failed to attach.");

                    return "";

                }

            }
            else
            {

                //create a new instance of Sap2000

                try
                {

                    //create OAPI helper object

                    cHelper myHelper = new Helper();



                    //get Sap2000 object

                    mySapObject = myHelper.CreateObject(ProgramPath);



                }
                catch (Exception ex)
                {

                    Console.WriteLine("Cannot start a new instance of the program.");

                    return "";

                }



                //start Sap2000 application

                mySapObject.ApplicationStart();

            }



            //create SapModel object

            var mySapModel = mySapObject.SapModel;



            int ret;

            //initialize model

            ret = mySapModel.InitializeNewModel((eUnits.kip_in_F));



            //create new blank model

            ret = mySapModel.File.NewBlank();



            //define material property

            ret = mySapModel.PropMaterial.SetMaterial("CONC", eMatType.Concrete, -1, "", "");



            //assign isotropic mechanical properties to material

            ret = mySapModel.PropMaterial.SetMPIsotropic("CONC", 3600, 0.2, 0.0000055, 0);



            //define rectangular frame section property

            ret = mySapModel.PropFrame.SetRectangle("R1", "CONC", 12, 12, -1, "", "");



            //define frame section property modifiers

            double[] ModValue = new double[8];

            int i;

            for (i = 0; i <= 7; i++)

            {

                ModValue[i] = 1;

            }

            ModValue[0] = 1000;

            ModValue[1] = 0;

            ModValue[2] = 0;

            ret = mySapModel.PropFrame.SetModifiers("R1", ref ModValue);



            //switch to k-ft units

            ret = mySapModel.SetPresentUnits(eUnits.kip_ft_F);



            //add frame object by coordinates

            string[] FrameName = new string[3];

            string temp_string1 = FrameName[0];

            string temp_string2 = FrameName[0];

            ret = mySapModel.FrameObj.AddByCoord(0, 0, 0, 0, 0, 10, ref temp_string1, "R1", "1", "Global");

            FrameName[0] = temp_string1;

            ret = mySapModel.FrameObj.AddByCoord(0, 0, 10, 8, 0, 16, ref temp_string1, "R1", "2", "Global");

            FrameName[1] = temp_string1;

            ret = mySapModel.FrameObj.AddByCoord(-4, 0, 10, 0, 0, 10, ref temp_string1, "R1", "3", "Global");

            FrameName[2] = temp_string1;



            //assign point object restraint at base

            string[] PointName = new string[2];

            bool[] Restraint = new bool[6];

            for (i = 0; i <= 3; i++)

            {

                Restraint[i] = true;

            }



            for (i = 4; i <= 5; i++)

            {

                Restraint[i] = false;

            }



            ret = mySapModel.FrameObj.GetPoints(FrameName[0], ref temp_string1, ref temp_string2);

            PointName[0] = temp_string1;

            PointName[1] = temp_string2;

            ret = mySapModel.PointObj.SetRestraint(PointName[0], ref Restraint, 0);



            //assign point object restraint at top

            for (i = 0; i <= 1; i++)

            {

                Restraint[i] = true;

            }



            for (i = 2; i <= 5; i++)

            {

                Restraint[i] = false;

            }



            ret = mySapModel.FrameObj.GetPoints(FrameName[1], ref temp_string1, ref temp_string2);

            PointName[0] = temp_string1;

            PointName[1] = temp_string2;

            ret = mySapModel.PointObj.SetRestraint(PointName[1], ref Restraint, 0);



            //refresh view, update (initialize) zoom

            bool temp_bool = false;

            ret = mySapModel.View.RefreshView(0, temp_bool);



            //add load patterns

            temp_bool = true;

            ret = mySapModel.LoadPatterns.Add("1", eLoadPatternType.Other, 1, temp_bool);

            ret = mySapModel.LoadPatterns.Add("2", eLoadPatternType.Other, 0, temp_bool);

            ret = mySapModel.LoadPatterns.Add("3", eLoadPatternType.Other, 0, temp_bool);

            ret = mySapModel.LoadPatterns.Add("4", eLoadPatternType.Other, 0, temp_bool);

            ret = mySapModel.LoadPatterns.Add("5", eLoadPatternType.Other, 0, temp_bool);

            ret = mySapModel.LoadPatterns.Add("6", eLoadPatternType.Other, 0, temp_bool);

            ret = mySapModel.LoadPatterns.Add("7", eLoadPatternType.Other, 0, temp_bool);



            //assign loading for load pattern 2

            ret = mySapModel.FrameObj.GetPoints(FrameName[2], ref temp_string1, ref temp_string2);

            PointName[0] = temp_string1;

            PointName[1] = temp_string2;

            double[] PointLoadValue = new double[6];

            PointLoadValue[2] = -10;

            ret = mySapModel.PointObj.SetLoadForce(PointName[0], "2", ref PointLoadValue, false, "Global", 0);

            ret = mySapModel.FrameObj.SetLoadDistributed(FrameName[2], "2", 1, 10, 0, 1, 1.8, 1.8, "Global", System.Convert.ToBoolean(-1), System.Convert.ToBoolean(-1), 0);



            //assign loading for load pattern 3

            ret = mySapModel.FrameObj.GetPoints(FrameName[2], ref temp_string1, ref temp_string2);

            PointName[0] = temp_string1;

            PointName[1] = temp_string2;

            PointLoadValue = new double[6];

            PointLoadValue[2] = -17.2;

            PointLoadValue[4] = -54.4;

            ret = mySapModel.PointObj.SetLoadForce(PointName[1], "3", ref PointLoadValue, false, "Global", 0);



            //assign loading for load pattern 4

            ret = mySapModel.FrameObj.SetLoadDistributed(FrameName[1], "4", 1, 11, 0, 1, 2, 2, "Global", System.Convert.ToBoolean(-1), System.Convert.ToBoolean(-1), 0);



            //assign loading for load pattern 5

            ret = mySapModel.FrameObj.SetLoadDistributed(FrameName[0], "5", 1, 2, 0, 1, 2, 2, "Local", System.Convert.ToBoolean(-1), System.Convert.ToBoolean(-1), 0);

            ret = mySapModel.FrameObj.SetLoadDistributed(FrameName[1], "5", 1, 2, 0, 1, -2, -2, "Local", System.Convert.ToBoolean(-1), System.Convert.ToBoolean(-1), 0);



            //assign loading for load pattern 6

            ret = mySapModel.FrameObj.SetLoadDistributed(FrameName[0], "6", 1, 2, 0, 1, 0.9984, 0.3744, "Local", System.Convert.ToBoolean(-1), System.Convert.ToBoolean(-1), 0);

            ret = mySapModel.FrameObj.SetLoadDistributed(FrameName[1], "6", 1, 2, 0, 1, -0.3744, 0, "Local", System.Convert.ToBoolean(-1), System.Convert.ToBoolean(-1), 0);



            //assign loading for load pattern 7

            ret = mySapModel.FrameObj.SetLoadPoint(FrameName[1], "7", 1, 2, 0.5, -15, "Local", System.Convert.ToBoolean(-1), System.Convert.ToBoolean(-1), 0);



            //switch to k-in units

            ret = mySapModel.SetPresentUnits(eUnits.kip_in_F);



            //save model

            ret = mySapModel.File.Save(ModelPath);



            //run model (this will create the analysis model)

            ret = mySapModel.Analyze.RunAnalysis();



            //initialize for Sap2000 results

            double[] SapResult = new double[7];

            ret = mySapModel.FrameObj.GetPoints(FrameName[1], ref temp_string1, ref temp_string2);

            PointName[0] = temp_string1;

            PointName[1] = temp_string2;


                /// ANTHONY CUSTOM CODE START ///


                //get point names
                int NumOfPoints = 0;
                string[] PointNames = new string[0];
                ret = mySapModel.PointObj.GetNameList(ref NumOfPoints, ref PointNames);

                //get point coords

                //must created reference variables
                double X = new double();
                double Y = new double();
                double Z = new double();
                //create list for extracted points
                List<SAP2000Point> extractedPoints = new List<SAP2000Point>();
                //cycle through all points, create point class, populate with data from API call, add to point list
                for (int t = 0; t < NumOfPoints; t++)
                {
                    ret = mySapModel.PointObj.GetCoordCartesian(PointNames[t], ref X, ref Y, ref Z);
                    SAP2000Point newPoint = new SAP2000Point();
                    //newPoint.X = X;
                    //newPoint.Y = Y;
                    //newPoint.Z = Z;
                    newPoint.id = PointNames[t];
                    extractedPoints.Add(newPoint);
                }



                string functionMessage = extractedPoints[2].id.ToString();

                return functionMessage;

                //get Sap2000 results for load patterns 1 through 7

                /*

                       int NumberResults = 0;

                       string[] Obj = new string[1];

                       string[] Elm = new string[1];

                       string[] LoadCase = new string[1];

                       string[] StepType = new string[1];

                       double[] StepNum = new double[1];

                       double[] U1 = new double[1];

                       double[] U2 = new double[1];

                       double[] U3 = new double[1];

                       double[] R1 = new double[1];

                       double[] R2 = new double[1];

                       double[] R3 = new double[1];



                       for (i = 0; i <= 6; i++)

                       {

                           ret = mySapModel.Results.Setup.DeselectAllCasesAndCombosForOutput();

                           ret = mySapModel.Results.Setup.SetCaseSelectedForOutput(System.Convert.ToString(i + 1), System.Convert.ToBoolean(-1));

                           if (i <= 3)

                           {

                               ret = mySapModel.Results.JointDispl(PointName[1], eItemTypeElm.ObjectElm, refNumberResults, ref Obj, ref Elm, ref LoadCase, ref StepType, ref StepNum, ref U1, ref U2, ref U3, ref R1, ref R2, ref R3);

                               U3.CopyTo(U3, 0);

                               SapResult[i] = U3[0];

                           }



                           else

                           {

                               ret = mySapModel.Results.JointDispl(PointName[0], eItemTypeElm.ObjectElm, refNumberResults, ref Obj, ref Elm, ref LoadCase, ref StepType, ref StepNum, ref U1, ref U2, ref U3, ref R1, ref R2, ref R3);

                               U1.CopyTo(U1, 0);

                               SapResult[i] = U1[0];

                           }



                       }

                   */


            //close Sap2000

            //mySapObject.ApplicationExit(false);

            //mySapModel = null;

            //mySapObject = null;



            //fill Sap2000 result strings


            /*
                    string[] SapResultString = new string[7];

                    for (i = 0; i <= 6; i++)

                    {

                        SapResultString[i] = string.Format("{0:0.00000}", SapResult[i]);

                        ret = (string.Compare(SapResultString[i], 1, "-", 1, 1, true));

                        if (ret != 0)

                        {

                            SapResultString[i] = " " + SapResultString[i];

                        }

                    }



                    //fill independent results

                    double[] IndResult = new double[7];

                    string[] IndResultString = new string[7];

                    IndResult[0] = -0.02639;

                    IndResult[1] = 0.06296;

                    IndResult[2] = 0.06296;

                    IndResult[3] = -0.2963;

                    IndResult[4] = 0.3125;

                    IndResult[5] = 0.11556;

                    IndResult[6] = 0.00651;

                    for (i = 0; i <= 6; i++)

                    {

                        IndResultString[i] = string.Format("{0:0.00000}", IndResult[i]);

                        ret = (string.Compare(IndResultString[i], 1, "-", 1, 1, true));

                        if (ret != 0)

                        {

                            IndResultString[i] = " " + IndResultString[i];

                        }

                    }



                    //fill percent difference

                    double[] PercentDiff = new double[7];

                    string[] PercentDiffString = new string[7];

                    for (i = 0; i <= 6; i++)

                    {

                        PercentDiff[i] = (SapResult[i] / IndResult[i]) - 1;

                        PercentDiffString[i] = string.Format("{0:0%}", PercentDiff[i]);

                        ret = (string.Compare(PercentDiffString[i], 1, "-", 1, 1, true));

                        if (ret != 0)

                        {

                            PercentDiffString[i] = " " + PercentDiffString[i];

                        }

                    }



                    //display message box comparing results

                    string msg = "";

                    msg = msg + "LC  Sap2000  Independent  %Diff\r\n";

                    for (i = 0; i <= 5; i++)

                    {

                        msg = msg + string.Format("{0:0}", i + 1) + "    " + SapResultString[i] + "   " + IndResultString[i] + "       " + PercentDiffString[i] + "\r\n";

                    }



                    msg = msg + string.Format("{0:0}", i + 1) + "    " + SapResultString[i] + "   " + IndResultString[i] + "       " + PercentDiffString[i];

                    Console.WriteLine(msg);

                    Console.ReadKey();

                */
            /*
                    }
                */

        }



