﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenTK;

namespace Sensor_Aware_PT
{
    /** Struct to hold info on each line of sensor data */
    [Serializable()]
    public class SensorDataEntry
    {
        public Vector3 orientation = new Vector3();
        public Vector3 accelerometer = new Vector3();
        public Vector3 gyroscope = new Vector3();
        public Vector3 magnetometer = new Vector3();
        public DateTime timeStamp = new DateTime();
        public TimeSpan timeSpan;
        public int sequenceNumber;
        public string id;

        public override string ToString()
        {
            return String.Format( "Sensor {12}:\nAngle{{{0},{1},{2}}}\n Accel{{{3},{4},{5}}}\n Mag{{{6},{7},{8}}}\n Gyro{{{9},{10},{11}}}",
         orientation.X,
         orientation.Y,
         orientation.Z,
         accelerometer.X,
         accelerometer.Y,
         accelerometer.Z,
         magnetometer.X,
         magnetometer.Y,
         magnetometer.Z,
         gyroscope.X,
         gyroscope.Y,
         gyroscope.Z ,
         id
         );
        }

        public Vector3 Orientation
        {
            get
            {
                return orientation;
            }
        }

        public String Id
        {
            get
            {
                return id;
            }
        }

        public long Timestamp
        {
            get
            {
                return ( long ) timeStamp.Ticks;
                
            }
        }

        public int Sequence
        {
            get
            {
                return sequenceNumber;
            }
        }
    }

    /** Holds ID and MAC of each sensor */
    public class SensorIdentification
    {
        public string Id;
        public string Mac;
        public string PortName;

        public SensorIdentification()
        {
            Id = Mac = PortName = String.Empty;
        }

        public SensorIdentification( string _id, string _mac, string port = "" )
        {
            Id = _id;
            Mac = _mac;
            PortName = port;
        }
    }
}