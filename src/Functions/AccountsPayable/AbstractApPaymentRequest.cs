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

    abstract public class AbstractApPaymentRequest : AbstractFunction
    {

        public static string PaymentMethodCheck = "Printed Check";

        public static string PaymentMethodCash = "Cash";

        public static string PaymentMethodRecordTransfer = "EFT";

        public static string PaymentMethodCreditCard = "Credit Card";

        public static string PaymentMethodACH = "ACH";

        public int? RecordNo;

        public string PaymentMethod;

        public string BankAccountId;

        public string ChargeCardId;

        public string VendorId;

        public string MergeOption;

        public bool? GroupPayments;

        public DateTime PaymentDate;

        public decimal TransactionAmount;

        public string DocumentNo;

        public string Memo;

        public string NotificationContactName;

        public List<ApPaymentRequestItem> ApplyToTransactions = new List<ApPaymentRequestItem>();
        
        public AbstractApPaymentRequest(string controlId = null) : base(controlId)
        {
        }
    }
}