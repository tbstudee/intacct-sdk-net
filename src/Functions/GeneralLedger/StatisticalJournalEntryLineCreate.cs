﻿/*
 * Copyright 2017 Intacct Corporation.
 * 
 * Licensed under the Apache License, Version 2.0 (the "License"). You may not
 * use this file except in compliance with the License. You may obtain a copy 
 * of the License at
 * 
 * http://www.apache.org/licenses/LICENSE-2.0
 * 
 * or in the "LICENSE" file accompanying this file. This file is distributed on 
 * an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either 
 * express or implied. See the License for the specific language governing 
 * permissions and limitations under the License.
 */

using Intacct.Sdk.Xml;
using System;
using System.Collections.Generic;

namespace Intacct.Sdk.Functions.GeneralLedger
{

    public class StatisticalJournalEntryLineCreate : AbstractStatisticalJournalEntryLine
    {

        public StatisticalJournalEntryLineCreate() : base()
        {
        }

        public override void WriteXml(ref IaXmlWriter xml)
        {
            xml.WriteStartElement("GLENTRY");

            xml.WriteElement("DOCUMENT", DocumentNumber);
            xml.WriteElement("ACCOUNTNO", StatAccountNumber, true);
            if (Amount < 0)
            {
                xml.WriteElement("TR_TYPE", "-1"); // Decrease
                xml.WriteElement("TRX_AMOUNT", Math.Abs(Amount.Value), true);
            }
            else
            {
                xml.WriteElement("TR_TYPE", "1"); // Increase
                xml.WriteElement("TRX_AMOUNT", Amount, true);
            }

            if (!String.IsNullOrWhiteSpace(AllocationId))
            {
                xml.WriteElement("ALLOCATION", AllocationId);

                if (AllocationId == CustomAllocationId)
                {
                    foreach (CustomAllocationSplit Split in CustomAllocationSplits)
                    {
                        Split.WriteXml(ref xml);
                    }
                }
            }
            else
            {
                xml.WriteElement("LOCATION", LocationId);
                xml.WriteElement("DEPARTMENT", DepartmentId);
                xml.WriteElement("PROJECTID", ProjectId);
                xml.WriteElement("CUSTOMERID", CustomerId);
                xml.WriteElement("VENDORID", VendorId);
                xml.WriteElement("EMPLOYEEID", EmployeeId);
                xml.WriteElement("ITEMID", ItemId);
                xml.WriteElement("CLASSID", ClassId);
                xml.WriteElement("CONTRACTID", ContractId);
                xml.WriteElement("WAREHOUSEID", WarehouseId);
            }

            xml.WriteElement("DESCRIPTION", Memo);

            xml.WriteCustomFieldsImplicit(CustomFields);

            xml.WriteEndElement(); //GLENTRY
        }

    }

}