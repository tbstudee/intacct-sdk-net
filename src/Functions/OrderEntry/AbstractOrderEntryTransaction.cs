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

using Intacct.Sdk.Functions.InventoryControl;
using Intacct.Sdk.Xml;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Intacct.Sdk.Functions.OrderEntry
{

    abstract public class AbstractOrderEntryTransaction : AbstractFunction
    {

        public string DocumentId;

        public string TransactionDefinition;

        public DateTime? TransactionDate;

        public DateTime? GlPostingDate;

        public string CreatedFrom;
        
        public string CustomerId;

        public string DocumentNumber;

        public DateTime? OriginalDocumentDate;

        public string ReferenceNumber;

        public string PaymentTerm;

        public DateTime? DueDate;

        public string Message;

        public string ShippingMethod;

        public string ShipToContactName;

        public string BillToContactName;

        public string AttachmentsId;

        public string ExternalId;
        
        public string BaseCurrency;

        public string TransactionCurrency;

        public DateTime? ExchangeRateDate;

        public decimal? ExchangeRateValue;

        public string ExchangeRateType;

        public string VsoePriceList;

        public string State;

        public string ProjectId;

        public List<AbstractTransactionSubtotal> Subtotals = new List<AbstractTransactionSubtotal>();

        public List<AbstractOrderEntryTransactionLine> Lines = new List<AbstractOrderEntryTransactionLine>();

        public Dictionary<string, dynamic> CustomFields = new Dictionary<string, dynamic>();

        public AbstractOrderEntryTransaction(string controlId = null) : base(controlId)
        {
        }
        
    }
}