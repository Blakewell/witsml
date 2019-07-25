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

using Energistics.DataAccess;
using Energistics.DataAccess.WITSML141;
using Energistics.DataAccess.WITSML141.ComponentSchemas;
using Energistics.DataAccess.WITSML141.ReferenceData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace PDS.WITSMLstudio.Store.Data.WellCMLedgers
{
    [TestClass]
    public partial class WellCMLedger141StoreTests : WellCMLedger141TestBase
    {
        public WellCMLedger141StoreTests()
            : base(false)
        {
        }

        [TestMethod]
        public void WellCMLedger141DataAdapter_GetFromStore_Can_Get_WellCMLedger()
        {
            AddParents();
            DevKit.AddAndAssert<WellCMLedgerList, WellCMLedger>(WellCMLedger);
            DevKit.GetAndAssert<WellCMLedgerList, WellCMLedger>(WellCMLedger);
       }

        [TestMethod]
        public void WellCMLedger141DataAdapter_AddToStore_Can_Add_WellCMLedger()
        {
            AddParents();
            DevKit.AddAndAssert<WellCMLedgerList, WellCMLedger>(WellCMLedger);
        }

        [TestMethod]
        public void WellCMLedger141DataAdapter_UpdateInStore_Can_Update_WellCMLedger()
        {
            AddParents();
            DevKit.AddAndAssert<WellCMLedgerList, WellCMLedger>(WellCMLedger);
            DevKit.UpdateAndAssert<WellCMLedgerList, WellCMLedger>(WellCMLedger);
            DevKit.GetAndAssert<WellCMLedgerList, WellCMLedger>(WellCMLedger);
        }

        [TestMethod]
        public void WellCMLedger141DataAdapter_DeleteFromStore_Can_Delete_WellCMLedger()
        {
            AddParents();
            DevKit.AddAndAssert<WellCMLedgerList, WellCMLedger>(WellCMLedger);
            DevKit.DeleteAndAssert<WellCMLedgerList, WellCMLedger>(WellCMLedger);
            DevKit.GetAndAssert<WellCMLedgerList, WellCMLedger>(WellCMLedger, isNotNull: false);
        }

        [TestMethod]
        public void WellCMLedger141DataAdapter_AddToStore_Creates_ChangeLog()
        {
            AddParents();

            DevKit.AddAndAssert<WellCMLedgerList, WellCMLedger>(WellCMLedger);

            var result = DevKit.GetAndAssert<WellCMLedgerList, WellCMLedger>(WellCMLedger);
            var expectedHistoryCount = 1;
            var expectedChangeType = ChangeInfoType.add;
            DevKit.AssertChangeLog(result, expectedHistoryCount, expectedChangeType);
        }

        [TestMethod]
        public void WellCMLedger141DataAdapter_UpdateInStore_Updates_ChangeLog()
        {
            AddParents();

            DevKit.AddAndAssert<WellCMLedgerList, WellCMLedger>(WellCMLedger);

            // Update the WellCMLedger141
            WellCMLedger.Name = "Change";
            DevKit.UpdateAndAssert(WellCMLedger);

            var result = DevKit.GetAndAssert<WellCMLedgerList, WellCMLedger>(WellCMLedger);
            var expectedHistoryCount = 2;
            var expectedChangeType = ChangeInfoType.update;
            DevKit.AssertChangeLog(result, expectedHistoryCount, expectedChangeType);
        }

        [TestMethod]
        public void WellCMLedger141DataAdapter_DeleteFromStore_Updates_ChangeLog()
        {
            AddParents();

            DevKit.AddAndAssert<WellCMLedgerList, WellCMLedger>(WellCMLedger);

            // Delete the WellCMLedger141
            DevKit.DeleteAndAssert(WellCMLedger);

            var expectedHistoryCount = 2;
            var expectedChangeType = ChangeInfoType.delete;
            DevKit.AssertChangeLog(WellCMLedger, expectedHistoryCount, expectedChangeType);
        }

        [TestMethod]
        public void WellCMLedger141DataAdapter_ChangeLog_Tracks_ChangeHistory_For_Add_Update_Delete()
        {
            AddParents();

            // Add the WellCMLedger141
            DevKit.AddAndAssert<WellCMLedgerList, WellCMLedger>(WellCMLedger);

            // Verify ChangeLog for Add
            var result = DevKit.GetAndAssert<WellCMLedgerList, WellCMLedger>(WellCMLedger);
            var expectedHistoryCount = 1;
            var expectedChangeType = ChangeInfoType.add;
            DevKit.AssertChangeLog(result, expectedHistoryCount, expectedChangeType);

            // Update the WellCMLedger141
            WellCMLedger.Name = "Change";
            DevKit.UpdateAndAssert(WellCMLedger);

            result = DevKit.GetAndAssert<WellCMLedgerList, WellCMLedger>(WellCMLedger);
            expectedHistoryCount = 2;
            expectedChangeType = ChangeInfoType.update;
            DevKit.AssertChangeLog(result, expectedHistoryCount, expectedChangeType);

            // Delete the WellCMLedger141
            DevKit.DeleteAndAssert(WellCMLedger);

            expectedHistoryCount = 3;
            expectedChangeType = ChangeInfoType.delete;
            DevKit.AssertChangeLog(WellCMLedger, expectedHistoryCount, expectedChangeType);

            // Re-add the same WellCMLedger141...
            DevKit.AddAndAssert<WellCMLedgerList, WellCMLedger>(WellCMLedger);

            //... the same changeLog should be reused.
            result = DevKit.GetAndAssert<WellCMLedgerList, WellCMLedger>(WellCMLedger);
            expectedHistoryCount = 4;
            expectedChangeType = ChangeInfoType.add;
            DevKit.AssertChangeLog(result, expectedHistoryCount, expectedChangeType);

            DevKit.AssertChangeHistoryTimesUnique(result);
        }

        [TestMethod]
        public void WellCMLedger141DataAdapter_GetFromStore_Filter_ExtensionNameValue()
        {
            AddParents();

            var extensionName1 = DevKit.ExtensionNameValue("Ext-1", "1.0", "m");
            var extensionName2 = DevKit.ExtensionNameValue("Ext-2", "2.0", "cm", PrimitiveType.@float);
            extensionName2.MeasureClass = MeasureClass.Length;
            var extensionName3 = DevKit.ExtensionNameValue("Ext-3", "3.0", "cm", PrimitiveType.unknown);

            WellCMLedger.CommonData = new CommonData()
            {
                ExtensionNameValue = new List<ExtensionNameValue>()
                {
                    extensionName1, extensionName2, extensionName3
                }
            };

            // Add the WellCMLedger141
            DevKit.AddAndAssert(WellCMLedger);

            // Query for first extension
            var commonDataXml = "<commonData>" + Environment.NewLine +
                                "<extensionNameValue uid=\"\">" + Environment.NewLine +
                                "<name />{0}" + Environment.NewLine +
                                "</extensionNameValue>" + Environment.NewLine +
                                "</commonData>";

            var extValueQuery = string.Format(commonDataXml, "<dataType>double</dataType>");
            var queryXml = string.Format(BasicXMLTemplate, WellCMLedger.UidWell, WellCMLedger.UidWellbore, WellCMLedger.Uid, extValueQuery);
            var result = DevKit.Query<WellCMLedgerList, WellCMLedger>(ObjectTypes.WellCMLedger, queryXml, null, OptionsIn.ReturnElements.Requested);
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);

            var resultWellCMLedger = result[0];
            Assert.IsNotNull(resultWellCMLedger);

            var commonData = resultWellCMLedger.CommonData;
            Assert.IsNotNull(commonData);
            Assert.AreEqual(1, commonData.ExtensionNameValue.Count);

            var env = commonData.ExtensionNameValue[0];
            Assert.IsNotNull(env);
            Assert.AreEqual(extensionName1.Uid, env.Uid);
            Assert.AreEqual(extensionName1.Name, env.Name);

            // Query for second extension
            extValueQuery = string.Format(commonDataXml, "<measureClass>length</measureClass>");
            queryXml = string.Format(BasicXMLTemplate, WellCMLedger.UidWell, WellCMLedger.UidWellbore, WellCMLedger.Uid, extValueQuery);
            result = DevKit.Query<WellCMLedgerList, WellCMLedger>(ObjectTypes.WellCMLedger, queryXml, null, OptionsIn.ReturnElements.Requested);
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);

            resultWellCMLedger = result[0];
            Assert.IsNotNull(resultWellCMLedger);

            commonData = resultWellCMLedger.CommonData;
            Assert.IsNotNull(commonData);
            Assert.AreEqual(1, commonData.ExtensionNameValue.Count);

            env = commonData.ExtensionNameValue[0];
            Assert.IsNotNull(env);
            Assert.AreEqual(extensionName2.Uid, env.Uid);
            Assert.AreEqual(extensionName2.Name, env.Name);

            // Query for third extension
            extValueQuery = string.Format(commonDataXml, "<dataType>unknown</dataType>");
            queryXml = string.Format(BasicXMLTemplate, WellCMLedger.UidWell, WellCMLedger.UidWellbore, WellCMLedger.Uid, extValueQuery);
            result = DevKit.Query<WellCMLedgerList, WellCMLedger>(ObjectTypes.WellCMLedger, queryXml, null, OptionsIn.ReturnElements.Requested);
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);

            resultWellCMLedger = result[0];
            Assert.IsNotNull(resultWellCMLedger);

            commonData = resultWellCMLedger.CommonData;
            Assert.IsNotNull(commonData);
            Assert.AreEqual(1, commonData.ExtensionNameValue.Count);

            env = commonData.ExtensionNameValue[0];
            Assert.IsNotNull(env);
            Assert.AreEqual(extensionName3.Uid, env.Uid);
            Assert.AreEqual(extensionName3.Name, env.Name);
        }

        [TestMethod]
        public void WellCMLedger141DataAdapter_ChangeLog_Syncs_WellCMLedger_Name_Changes()
        {
            AddParents();

            // Add the WellCMLedger141
            DevKit.AddAndAssert<WellCMLedgerList, WellCMLedger>(WellCMLedger);

            // Assert that all WellCMLedger names match corresponding changeLog names
            DevKit.AssertChangeLogNames(WellCMLedger);

            // Update the WellCMLedger141 names
            WellCMLedger.Name = "Change";
            WellCMLedger.NameWell = "Well Name Change";

            WellCMLedger.NameWellbore = "Wellbore Name Change";

            DevKit.UpdateAndAssert(WellCMLedger);

            // Assert that all WellCMLedger names match corresponding changeLog names
            DevKit.AssertChangeLogNames(WellCMLedger);
        }
    }
}