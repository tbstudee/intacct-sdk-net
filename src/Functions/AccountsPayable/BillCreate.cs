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

namespace Intacct.Sdk.Functions.AccountsPayable
{

    public class BillCreate : AbstractBill
    {

        public BillCreate(string controlId = null) : base(controlId)
        {
        }

        public override void WriteXml(ref IaXmlWriter xml)
        {
            xml.WriteStartElement("function");
            xml.WriteAttribute("controlid", ControlId, true);

            xml.WriteStartElement("create_bill");
            
            xml.WriteElement("vendorid", VendorId, true);

            xml.WriteStartElement("datecreated");
            xml.WriteDateSplitElements(TransactionDate.Value);
            xml.WriteEndElement(); //datecreated

            if (GlPostingDate.HasValue)
            {
                xml.WriteStartElement("dateposted");
                xml.WriteDateSplitElements(GlPostingDate.Value);
                xml.WriteEndElement(); //dateposted
            }

            if (DueDate.HasValue)
            {
                xml.WriteStartElement("datedue");
                xml.WriteDateSplitElements(DueDate.Value);
                xml.WriteEndElement(); //datedue

                xml.WriteElement("termname", PaymentTerm);
            } else
            {
                xml.WriteElement("termname", PaymentTerm, true);
            }

            xml.WriteElement("action", Action);
            xml.WriteElement("batchkey", SummaryRecordNo);
            xml.WriteElement("billno", BillNumber);
            xml.WriteElement("ponumber", ReferenceNumber);
            xml.WriteElement("onhold", OnHold);
            xml.WriteElement("description", Description);
            xml.WriteElement("externalid", ExternalId);

            if (!String.IsNullOrWhiteSpace(PayToContactName))
            {
                xml.WriteStartElement("payto");
                xml.WriteElement("contactname", PayToContactName);
                xml.WriteEndElement(); //payto
            }
            if (!String.IsNullOrWhiteSpace(ReturnToContactName))
            {
                xml.WriteStartElement("returnto");
                xml.WriteElement("contactname", ReturnToContactName);
                xml.WriteEndElement(); //returnto
            }

            WriteXmlMultiCurrencySection(ref xml);

            xml.WriteElement("nogl", DoNotPostToGL);
            xml.WriteElement("supdocid", AttachmentsId);

            xml.WriteCustomFieldsExplicit(CustomFields);

            xml.WriteStartElement("billitems");
            if (Lines.Count > 0)
            {
                foreach (BillLineCreate Line in Lines)
                {
                    Line.WriteXml(ref xml);
                }
            }
            xml.WriteEndElement(); //billitems

            xml.WriteEndElement(); //create_bill

            xml.WriteEndElement(); //function
        }

    }

}