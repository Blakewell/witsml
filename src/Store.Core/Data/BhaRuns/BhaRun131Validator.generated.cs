//----------------------------------------------------------------------- 
// PDS WITSMLstudio Store, 2018.3
//
// Copyright 2018 PDS Americas LLC
// 
// Licensed under the PDS Open Source WITSML Product License Agreement (the
// "License"); you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   
//     http://www.pds.group/WITSMLstudio/OpenSource/ProductLicenseAgreement
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//-----------------------------------------------------------------------

// ----------------------------------------------------------------------
// <auto-generated>
//     Changes to this file may cause incorrect behavior and will be lost
//     if the code is regenerated.
// </auto-generated>
// ----------------------------------------------------------------------
using System.ComponentModel.Composition;
using Energistics.DataAccess.WITSML131;
using PDS.WITSMLstudio.Framework;

namespace PDS.WITSMLstudio.Store.Data.BhaRuns
{
    /// <summary>
    /// Provides validation for <see cref="BhaRun" /> data objects.
    /// </summary>
    /// <seealso cref="PDS.WITSMLstudio.Store.Data.DataObjectValidator{BhaRun}" />
    [Export(typeof(IDataObjectValidator<BhaRun>))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class BhaRun131Validator : WellboreDataObjectValidator<BhaRun, Wellbore, Well>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BhaRun131Validator" /> class.
        /// </summary>
        /// <param name="container">The composition container.</param>
        /// <param name="bhaRunDataAdapter">The bhaRun data adapter.</param>
        /// <param name="wellboreDataAdapter">The wellbore data adapter.</param>
        /// <param name="wellDataAdapter">The well data adapter.</param>
        [ImportingConstructor]
        public BhaRun131Validator(
            IContainer container,
            IWitsmlDataAdapter<BhaRun> bhaRunDataAdapter,
            IWitsmlDataAdapter<Wellbore> wellboreDataAdapter,
            IWitsmlDataAdapter<Well> wellDataAdapter)
            : base(container, bhaRunDataAdapter, wellboreDataAdapter, wellDataAdapter)
        {
        }
    }
}