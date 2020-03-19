//******************************************************************************************************
//  AdoDatabaseExt.cs - Gbtc
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
using GSF.Data;


namespace PQio.Model
{
    public static class ModelID
    {
        public static int GetID<T>(AdoDataConnection cxn)
        {
            string Name = typeof(T).Name;
            string m_identitySQL;
            switch (cxn.DatabaseType)
            {
                case DatabaseType.SQLServer:
                    m_identitySQL = "SELECT IDENT_CURRENT('" + Name + "')";
                    break;

                case DatabaseType.Oracle:
                    m_identitySQL = "SELECT SEQ_" + Name + ".CURRVAL from dual";
                    break;

                case DatabaseType.SQLite:
                    m_identitySQL = "SELECT last_insert_rowid()";
                    break;

                //case DatabaseType.PostgreSQL:
                //    if ((object)AutoIncField != null)
                //        m_identitySQL = "SELECT currval(pg_get_serial_sequence('" + Name.ToLower() + "', '" + AutoIncField.Name.ToLower() + "'))";
                //    else
                //        m_identitySQL = "SELECT lastval()";
                //   break;

                default:
                    m_identitySQL = "SELECT @@IDENTITY";
                    break;
            }

            return Convert.ToInt32(cxn.ExecuteScalar(m_identitySQL));
        }

    }
    

}
