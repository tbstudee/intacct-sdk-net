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

using Intacct.Sdk.Exceptions;
using Intacct.Sdk.Xml.Response;
using System.IO;

namespace Intacct.Sdk.Xml
{

    public class AsynchronousResponse : AbstractResponse
    {

        private Acknowledgement acknowledgement;
        public Acknowledgement Acknowledgement
        {
            get { return acknowledgement; }
            private set
            {
                acknowledgement = value;
            }
        }

        public AsynchronousResponse(Stream body) : base(body)
        {
            if (xml.Element("response").Element("acknowledgement") == null)
            {
                throw new IntacctException("Response is missing acknowledgement block");
            }
            Acknowledgement = new Acknowledgement(xml.Element("response").Element("acknowledgement"));
        }

    }

}
