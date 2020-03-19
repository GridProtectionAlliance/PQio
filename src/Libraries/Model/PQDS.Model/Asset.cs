//******************************************************************************************************
//  Asset.cs - Gbtc
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
using Newtonsoft.Json;


namespace PQio.Model
{
    public class Asset
    {
        #region[Properties]

        [PrimaryKey(true)]
        public int ID { get; set; }

        public double? NominalVoltage { get; set; }

        public double? NominalFrequency { get; set; }

        public double? UpstreamXFMR { get; set; }

        public double? Length { get; set; }

        [Required]
        [StringLength(50)]
        public string AssetKey { get; set; }

        #endregion[Properties]

        #region[Methods]

        public override string ToString()
        {
            return this.AssetKey;
        }

        #endregion[Methods]
    }

    public class AssetToEvent
    {
        public int EventID { get; set; }
        public int AssetID { get; set; }
        public int DataSeriesID { get; set; }
    }
}

    //public static partial class TableOperationsExtensions
    //{
    //    public static Asset GetOrAdd(this TableOperations<Asset> AssetTable, string name, string description = null)
    //    {
    //        Asset phase = AssetTable.QueryRecordWhere("Name = {0}", name);
    //
    //        if ((object)phase == null)
    /*        {
                phase = new Phase();
                phase.Name = name;
                phase.Description = description ?? name;

                try
                {
                    phaseTable.AddNewRecord(phase);
                }
                catch (Exception ex)
                {
                    // Ignore errors regarding unique key constraints
                    // which can occur as a result of a race condition
                    bool isUniqueViolation = ExceptionHandler.IsUniqueViolation(ex);

                    if (!isUniqueViolation)
                        throw;

                    return phaseTable.QueryRecordWhere("Name = {0}", name);
                }

                phase.ID = phaseTable.Connection.ExecuteScalar<int>("SELECT @@IDENTITY");
            }

            return phase;
        } */

