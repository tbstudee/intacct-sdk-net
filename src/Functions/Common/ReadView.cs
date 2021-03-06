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
using System.Collections.ObjectModel;

namespace Intacct.Sdk.Functions.Common
{

    public class ReadView : AbstractFunction
    {

        private static readonly IList<string> ReturnFormats = new ReadOnlyCollection<string>(
            new List<string> {
                "xml",
            }
        );

        const string DefaultReturnFormat = "xml";

        const int MinPageSize = 1;

        const int MaxPageSize = 1000;

        const int DefaultPageSize = 1000;

        private string viewName;
        public string ViewName
        {
            get { return viewName; }
            set
            {
                viewName = value;
            }
        }

        private int pageSize;
        public int PageSize
        {
            get { return pageSize; }
            set
            {
                if (value < MinPageSize)
                {
                    throw new ArgumentException("Page Size cannot be less than " + MinPageSize.ToString());
                }
                else if (value > MaxPageSize)
                {
                    throw new ArgumentException("Page Size cannot be greater than " + MaxPageSize.ToString());
                }
                pageSize = value;
            }
        }

        private string returnFormat;
        public string ReturnFormat
        {
            get { return returnFormat; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    value = DefaultReturnFormat;
                }

                if (!ReturnFormats.Contains(value))
                {
                    throw new ArgumentException("Return Format is not a valid format");
                }

                returnFormat = value;
            }
        }

        public ReadView(string controlId = null) : base(controlId)
        {
            PageSize = DefaultPageSize;
            ReturnFormat = DefaultReturnFormat;
        }

        public override void WriteXml(ref IaXmlWriter xml)
        {
            xml.WriteStartElement("function");
            xml.WriteAttribute("controlid", ControlId, true);

            xml.WriteStartElement("readView");

            if (String.IsNullOrWhiteSpace(ViewName))
            {
                throw new ArgumentException("View Name is required for read view");
            }
            xml.WriteElement("view", ViewName, true);
            xml.WriteElement("pagesize", PageSize);
            xml.WriteElement("returnFormat", ReturnFormat);

            xml.WriteEndElement(); //readView

            xml.WriteEndElement(); //function
        }

    }

}