﻿// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Batch;
using Microsoft.Azure.Commands.Batch.Properties;
using System;
using System.Collections.Generic;
using System.IO;

namespace Microsoft.Azure.Commands.Batch.Models
{
    public class DownloadVMFileOptions : VMFileOperationParameters
    {
        public DownloadVMFileOptions(BatchAccountContext context, string poolName, string vmName, string vmFileName, PSVMFile vmFile, string destinationPath, 
            Stream stream, IEnumerable<BatchClientBehavior> additionalBehaviors = null) : base(context, poolName, vmName, vmFileName, vmFile, additionalBehaviors)
        {
            if (string.IsNullOrWhiteSpace(destinationPath) && stream == null)
            {
                throw new ArgumentNullException(Resources.NoDownloadDestination);
            }

            this.DestinationPath = destinationPath;
            this.Stream = stream;
        }

        /// <summary>
        /// The path to the directory where the vm file will be downloaded
        /// </summary>
        public string DestinationPath { get; set; }

        /// <summary>
        /// The Stream into which the vm file data will be written. This stream will not be closed or rewound by this call.
        /// </summary>
        internal Stream Stream { get; set; }
    }
}