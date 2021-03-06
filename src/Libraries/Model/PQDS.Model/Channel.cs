﻿//******************************************************************************************************
//  Channel.cs - Gbtc
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


using System.ComponentModel.DataAnnotations;
using GSF.Data.Model;

namespace PQio.Model
{
    public class Channel
    {

        [PrimaryKey(true)]
        public int ID { get; set; }

        public int MeterID { get; set; }

        public int? SignalType { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(2)]
        public string MeasurementType { get; set; }

        public int? AssetID { get; set; }
    }

}