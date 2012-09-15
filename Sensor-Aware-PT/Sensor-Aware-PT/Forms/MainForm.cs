﻿using System;
using System.Text;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;
using OpenTK;
using System.Collections.Generic;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System.ComponentModel;
using System.Diagnostics;

namespace Sensor_Aware_PT
{
    public partial class MainForm : Form
    {
        private Nexus mSensorManager;
        
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();

            foreach( string s in ports )
            {
                Logger.Info( "{0}", s );
            }
            
            mSensorManager = Nexus.Instance;
            mSensorManager.InitializationComplete += new Nexus.InitializationCompleteHandler( mSensorManager_NexusInitializedEvent );
            
            mSensorManager.initialize();
        }

        /// <summary>
        /// Handles the nexus ready event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void mSensorManager_NexusInitializedEvent( object sender, EventArgs e )
        {
            ///** If the nexus is now ready, query for the active sensors and attach a cuboid window to them */
            //List<Sensor> activeSensors = mSensorManager.getActivatedSensors();
            ////foreach( Sensor s in activeSensors )
            ////attachCuboidWindow( s );
            //{
            //    Sensor s = activeSensors[ 0 ];
            //    Sensor s2 = activeSensors[ 1 ];
            //    Sensor s3 = activeSensors[ 2 ];
            //    Sensor s4 = activeSensors[ 3 ];
            //    ExperimentalForm cuboid = new ExperimentalForm( s, s2,s3, s4,mSensorManager );
            //    /** Create background worker to show the form and run it asynchronously */
            //    BackgroundWorker cuboidWorker = new BackgroundWorker();
            //    cuboidWorker.DoWork += new DoWorkEventHandler( delegate
            //    {
            //        cuboid.ShowDialog();

            //    } );
            //    cuboidWorker.RunWorkerAsync();
            //}
            
            //mSensorManager.Subscribe( this );

            

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //bRunning = false;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
           // Thread.CurrentThread.Join();
           // port.Close();
        }


        private void button1_Click( object sender, EventArgs e )
        {
            /*

            BackgroundWorker bg = new BackgroundWorker();

            bg.DoWork += new DoWorkEventHandler( delegate
            {
                EF.ShowDialog();
            } );

            bg.RunWorkerAsync();
             * */
            ExperimentalForm EF = new ExperimentalForm();
            EF.subscribeToSource( Nexus.Instance );
            EF.Show();
        }

        private void button2_Click( object sender, EventArgs e )
        {
            /*
            BackgroundWorker bg = new BackgroundWorker();

            bg.DoWork += new DoWorkEventHandler( delegate
            {
                SDV.ShowDialog();
                
            } );

            bg.RunWorkerAsync();
             * */
            SensorDataView SDV = new SensorDataView();
            SDV.Show();
        }

        private void button3_Click( object sender, EventArgs e )
        {

        }
    }
}
