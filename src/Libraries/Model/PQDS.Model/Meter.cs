//******************************************************************************************************
//  Meter.cs - Gbtc
//
//  Copyright © 2020, Grid Protection Alliance.  All Rights Reserved.
//
//  Licensed to the Grid Protection Alliance (GPA) under one or more contributor license agreements. See
//  the NOTICE file distributed with this work for additional information regarding copyright ownership.
//  The GPA licenses this file to you under the MIT License (MIT), the "License"; you may
//  not use this file except in compliance with the License. You may obtain a copy of the License at:
//
//      http://www.opensource.org/licenses/MIT
//
//  Unless agreed to in writing, the subject software distributed under the License is distributed on an
//  "AS-IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. Refer to the
//  License for the specific language governing permissions and limitations.
//
//  Code Modification History:
//  ----------------------------------------------------------------------------------------------------
//  03/18/2020 - C. Lackner
//       Original version of source code generated.
//
//******************************************************************************************************



using System;
using System.ComponentModel.DataAnnotations;
using GSF.Data.Model;

namespace PQio.Model
{
    public class Meter
    {
        [PrimaryKey(true)]
        public int ID { get; set; }

        [StringLength(50)]
        public string DeviceName { get; set; }

        [StringLength(50)]
        public string DeviceAlias { get; set; }

        [StringLength(50)]
        public string DeviceLocation { get; set; }

        [StringLength(50)]
        public string DeviceLocationAlias { get; set; }

        public double? Latitude { get; set; }

        public double? Longitude { get; set; }

        [StringLength(50)]
        public string AccountName { get; set; }

        [StringLength(50)]
        public string AccountAlias { get; set; }

        public double? DistanceToXFR { get; set; }

        [StringLength(50)]
        public string Owner { get; set; }

        public int? ConnectionType { get; set; }

    }
   
    public static partial class TableOperationsExtensions
    {
        public static Meter GetOrAdd(this TableOperations<Meter> eventTypeTable, string name, string alias)
        {
            Meter meter = eventTypeTable.QueryRecordWhere("DeviceName = {0}", name);

            if ((object)meter == null)
            {
                meter = new Meter();
                meter.DeviceName = name;
                meter.DeviceAlias = alias ?? name;

                try
                {
                    eventTypeTable.AddNewRecord(meter);
                }
                catch (Exception ex)
                {
                    return eventTypeTable.QueryRecordWhere("DeviceName = {0}", name);
                }

                meter.ID = eventTypeTable.Connection.ExecuteScalar<int>("SELECT @@IDENTITY");
            }

            return meter;
        }

    }

}
