//******************************************************************************************************
//  DataSensitivity.cs - Gbtc
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
using System.Linq;
using GSF.Data;
using GSF.Data.Model;

namespace PQio.Model
{

    public class DataSensitivity
    {
        [PrimaryKey(true)]
        public int ID { get; set; }

        [StringLength(250)]
        public string Note { get; set; }

        public int Event { get; set; }

        public int Asset { get; set; }

        public int? DataSensitivityCode { get; set; }

        public static bool NoteisGlobal()
        {
            using (AdoDataConnection connection = new AdoDataConnection("systemSettings"))
            {
                GSF.Data.Model.TableOperations<DataSensitivity> tableOperations = new GSF.Data.Model.TableOperations<DataSensitivity>(connection);

                int uniqueDataSensitivityNotes = tableOperations.QueryRecordsWhere("Note NOT NULL AND Note <> ''").Select(record => record.Note.ToLower()).Distinct().Count();

                if (uniqueDataSensitivityNotes == 1)
                    return true;
            }
            return false;
        }

        public static bool CodeisGlobal()
        {
            using (AdoDataConnection connection = new AdoDataConnection("systemSettings"))
            {
                GSF.Data.Model.TableOperations<DataSensitivity> tableOperations = new GSF.Data.Model.TableOperations<DataSensitivity>(connection);

                int uniqueDataSensitivity = tableOperations.QueryRecordsWhere("DataSensitivityCode NOT NULL")
                    .Select(record => record.DataSensitivityCode).Distinct().Count();

                if (uniqueDataSensitivity == 1)
                    return true;
            }
            return false;
        }
    }
}
