//----------------------------------------------------------------------- 
// PDS.Witsml.Server, 2016.1
//
// Copyright 2016 Petrotechnical Data Systems
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//-----------------------------------------------------------------------

using System.Collections.Generic;
using Energistics.DataAccess.WITSML200;
using Energistics.DataAccess.WITSML200.ComponentSchemas;
using Energistics.Datatypes;

namespace PDS.Witsml.Server.Data.ChannelSets
{
    /// <summary>
    /// Data provider that implements support for WITSML API functions for <see cref="ChannelSet"/>.
    /// </summary>
    public partial class ChannelSet200DataProvider
    {
        /// <summary>
        /// Sets additional default values for the specified data object.
        /// </summary>
        /// <param name="dataObject">The data object.</param>
        partial void SetAdditionalDefaultValues(ChannelSet dataObject)
        {
            dataObject.Channel.ForEach(c => c.Uuid = c.NewUuid());
        }

        /// <summary>
        /// Sets additional default values for the specified data object and URI.
        /// </summary>
        /// <param name="dataObject">The data object.</param>
        /// <param name="uri">The data object URI.</param>
        partial void SetAdditionalDefaultValues(ChannelSet dataObject, EtpUri uri)
        {
            if (string.IsNullOrWhiteSpace(dataObject.TimeDepth))
                dataObject.TimeDepth = "time";

            if (string.IsNullOrWhiteSpace(dataObject.CurveClass))
                dataObject.CurveClass = "unknown";

            if (string.IsNullOrWhiteSpace(dataObject.LoggingCompanyName))
                dataObject.LoggingCompanyName = "unknown";

            if (dataObject.Index == null)
                dataObject.Index = new List<ChannelIndex>();

            if (dataObject.Channel == null)
                dataObject.Channel = new List<Channel>();
        }
    }
}