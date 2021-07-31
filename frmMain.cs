using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Timers;
using System.Windows.Forms;

// Add these two statements to all SimConnect clients
using Microsoft.FlightSimulator.SimConnect;
using System.Runtime.InteropServices;

namespace TCalc_004
{


    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private SimConnect my_simconnect;
        private static System.Timers.Timer timerRequest;

        /// <summary>
        /// Connect and disconnect to the sim
        /// </summary>
        /// <remarks>
        /// Called by btnConnect_click
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Simconnect_Connect(object sender, EventArgs e)
        {
            if (my_simconnect == null)
            {
                lblStatus.Text = "Connecting...";
                try
                {
                    my_simconnect = new SimConnect("Managed Data Request", base.Handle, 0x402, null, 0);
                    initDataRequest();
                    StartTimer(1);
                }
                catch (COMException)
                {
                    lblStatus.Text = "Unable to connect to sim";
                    return;
                }

                lblStatus.Text = "Connected";
                btnConnect.Text = "Disconnect";
            }
            else
            {
                closeConnection();
            }
        }

        private void StartTimer(int time)
        {
            timerRequest = new System.Timers.Timer(time*1000);
            timerRequest.Elapsed += OnTimedEvent;
            timerRequest.AutoReset = false;
            timerRequest.Enabled = true;
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            try
            {
                lblStatus.Text = "Requesting data";
                my_simconnect.RequestDataOnSimObjectType(DATA_REQUESTS.REQUEST_1, DEFINITIONS.Struct1, 0, SIMCONNECT_SIMOBJECT_TYPE.USER);
            }
            catch (NullReferenceException exception1)
            {
                lblStatus.Text = "Error requesting data"+ exception1;
                return;
            }
            StartTimer(5);
        }

        /// <summary>
        /// Close the simconnect connection
        /// </summary>
        private void closeConnection()
        {
            if (my_simconnect != null)
            {
                timerRequest.Stop();
                my_simconnect.Dispose();
                my_simconnect = null;
                lblStatus.Text = "Disconnected";
                btnConnect.Text = "Connect";
            }
        }

        protected override void DefWndProc(ref Message m)
        {
            if (m.Msg == 0x402)
            {
                if (my_simconnect != null)
                {
                    my_simconnect.ReceiveMessage();
                }
            }
            else
            {
                base.DefWndProc(ref m);
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            closeConnection();
        }

        private void initDataRequest()
        {
            try
            {
                my_simconnect.OnRecvOpen += new SimConnect.RecvOpenEventHandler(simconnect_OnRecvOpen);
                my_simconnect.OnRecvQuit += new SimConnect.RecvQuitEventHandler(simconnect_OnRecvQuit);
                my_simconnect.OnRecvException += new SimConnect.RecvExceptionEventHandler(simconnect_OnRecvException);
                my_simconnect.AddToDataDefinition(DEFINITIONS.Struct1, "Title", null, SIMCONNECT_DATATYPE.STRING256, 0.0f, SimConnect.SIMCONNECT_UNUSED);
                my_simconnect.AddToDataDefinition(DEFINITIONS.Struct1, "Plane Latitude", "degrees", SIMCONNECT_DATATYPE.FLOAT64, 0.0f, SimConnect.SIMCONNECT_UNUSED);
                my_simconnect.AddToDataDefinition(DEFINITIONS.Struct1, "Plane Longitude", "degrees", SIMCONNECT_DATATYPE.FLOAT64, 0.0f, SimConnect.SIMCONNECT_UNUSED);
                my_simconnect.AddToDataDefinition(DEFINITIONS.Struct1, "Plane Heading Degrees True", "degrees", SIMCONNECT_DATATYPE.FLOAT64, 0.0f, SimConnect.SIMCONNECT_UNUSED);
                my_simconnect.AddToDataDefinition(DEFINITIONS.Struct1, "Ground Altitude", "meters", SIMCONNECT_DATATYPE.FLOAT64, 0.0f, SimConnect.SIMCONNECT_UNUSED);
                my_simconnect.AddToDataDefinition(DEFINITIONS.Struct1, "Ground Velocity", "knots", SIMCONNECT_DATATYPE.FLOAT64, 0.0f, SimConnect.SIMCONNECT_UNUSED);
                my_simconnect.AddToDataDefinition(DEFINITIONS.Struct1, "G Force", "GForce", SIMCONNECT_DATATYPE.FLOAT64, 0.0f, SimConnect.SIMCONNECT_UNUSED);
                my_simconnect.AddToDataDefinition(DEFINITIONS.Struct1, "Simulation Rate", "number", SIMCONNECT_DATATYPE.FLOAT64, 0.0f, SimConnect.SIMCONNECT_UNUSED);
                my_simconnect.RegisterDataDefineStruct<Struct1>(DEFINITIONS.Struct1);
                my_simconnect.OnRecvSimobjectDataBytype += new SimConnect.RecvSimobjectDataBytypeEventHandler(simconnect_OnRecvSimobjectDataBytype);
            }
            catch (COMException exception1)
            {
                lblStatus.Text = "An error occured!";
                Console.WriteLine(exception1);
            }
        }

        private void simconnect_OnRecvException(SimConnect sender, SIMCONNECT_RECV_EXCEPTION data)
        {
            lblStatus.Text = "Exception received: " + ((uint)data.dwException);
        }

        private void simconnect_OnRecvOpen(SimConnect sender, SIMCONNECT_RECV_OPEN data)
        {
            lblStatus.Text = "Connected to sim";
        }

        private void simconnect_OnRecvQuit(SimConnect sender, SIMCONNECT_RECV data)
        {
            lblStatus.Text = "sim has exited";
            closeConnection();
        }

        /// <summary>
        /// This function is called when data is returned.
        /// </summary>
        /// <param name="sender">SimConnect sender</param>
        /// <param name="data">The returned data</param>
        private void simconnect_OnRecvSimobjectDataBytype(SimConnect sender, SIMCONNECT_RECV_SIMOBJECT_DATA_BYTYPE data)
        {

            if (data.dwRequestID == 0)
            {
                Struct1 struct1 = (Struct1)data.dwData[0];
                // label_aircraft.Text = struct1.title.ToString();
                textBox_latitude.Text = struct1.latitude.ToString();
                textBox_longitude.Text = struct1.longitude.ToString();
                textBox_trueheading.Text = struct1.trueheading.ToString();
                textBox_groundaltitude.Text = struct1.groundaltitude.ToString();
                textBox_groundaltitude.Text = struct1.groundvelocity.ToString();
                textBox_groundaltitude.Text = struct1.gforce.ToString();
                //textBox_groundaltitude.Text = struct1.simrate.ToString();
            }
            else
            {
                lblStatus.Text = "Unknown request ID: " + ((uint)data.dwRequestID);
            }
        }


        private enum DATA_REQUESTS
        {
            REQUEST_1
        }

        private enum DEFINITIONS
        {
            Struct1
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        private struct Struct1
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x100)]
            public string title;
            public double latitude;
            public double longitude;
            public double trueheading;
            public double groundaltitude;
            public double groundvelocity;
            public double gforce;
            public double simrate;
        }
    }
}

