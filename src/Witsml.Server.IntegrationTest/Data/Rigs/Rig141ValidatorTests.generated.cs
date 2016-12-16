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

// ----------------------------------------------------------------------
// <auto-generated>
//     Changes to this file may cause incorrect behavior and will be lost
//     if the code is regenerated.
// </auto-generated>
// ----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using Energistics.DataAccess;
using Energistics.DataAccess.WITSML141;
using Energistics.DataAccess.WITSML141.ComponentSchemas;
using Energistics.DataAccess.WITSML141.ReferenceData;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PDS.Witsml.Server.Data.Rigs
{
    [TestClass]
    public partial class Rig141ValidatorTests : Rig141TestBase
    {

        #region Error -401

        public static readonly string QueryInvalidPluralRoot =
            "<rig xmlns=\"http://www.witsml.org/schemas/1series\" version=\"1.4.1.1\">" + Environment.NewLine +
            "  <rig>" + Environment.NewLine +
            "    <name>Test Plural Root Element</name>" + Environment.NewLine +
            "  </rig>" + Environment.NewLine +
            "</rig>";

        [TestMethod]
        public void Rig141Validator_GetFromStore_Error_401_No_Plural_Root_Element()
        {
            var response = DevKit.GetFromStore(ObjectTypes.Rig, QueryInvalidPluralRoot, null, null);
            Assert.AreEqual((short)ErrorCodes.MissingPluralRootElement, response.Result);
        }

        [TestMethod]
        public void Rig141Validator_AddToStore_Error_401_No_Plural_Root_Element()
        {
            var response = DevKit.AddToStore(ObjectTypes.Rig, QueryInvalidPluralRoot, null, null);
            Assert.AreEqual((short)ErrorCodes.MissingPluralRootElement, response?.Result);
        }

        [TestMethod]
        public void Rig141Validator_UpdateInStore_Error_401_No_Plural_Root_Element()
        {
            var response = DevKit.UpdateInStore(ObjectTypes.Rig, QueryInvalidPluralRoot, null, null);
            Assert.AreEqual((short)ErrorCodes.MissingPluralRootElement, response?.Result);
        }

        [TestMethod]
        public void Rig141Validator_DeleteFromStore_Error_401_No_Plural_Root_Element()
        {
            var response = DevKit.DeleteFromStore(ObjectTypes.Rig, QueryInvalidPluralRoot, null, null);
            Assert.AreEqual((short)ErrorCodes.MissingPluralRootElement, response?.Result);
        }

        #endregion Error -401

        #region Error -402

        #endregion Error -402

        #region Error -403

        [TestMethod]
        public void Rig141Validator_GetFromStore_Error_403_RequestObjectSelectionCapability_True_MissingNamespace()
        {
            var response = DevKit.GetFromStore(ObjectTypes.Rig, QueryMissingNamespace, null, optionsIn: OptionsIn.RequestObjectSelectionCapability.True);
            Assert.AreEqual((short)ErrorCodes.MissingDefaultWitsmlNamespace, response.Result);
        }

        [TestMethod]
        public void Rig141Validator_GetFromStore_Error_403_RequestObjectSelectionCapability_True_BadNamespace()
        {
            var response = DevKit.GetFromStore(ObjectTypes.Rig, QueryInvalidNamespace, null, optionsIn: OptionsIn.RequestObjectSelectionCapability.True);
            Assert.AreEqual((short)ErrorCodes.MissingDefaultWitsmlNamespace, response.Result);
        }

        [TestMethod]
        public void Rig141Validator_GetFromStore_Error_403_RequestObjectSelectionCapability_None_BadNamespace()
        {
            var response = DevKit.GetFromStore(ObjectTypes.Rig, QueryInvalidNamespace, null, optionsIn: OptionsIn.RequestObjectSelectionCapability.None);
            Assert.AreEqual((short)ErrorCodes.MissingDefaultWitsmlNamespace, response.Result);
        }

        #endregion Error -403

		#region Error -405

		[TestMethod]
        public void Rig141Validator_AddToStore_Error_405_Rig_Already_Exists()
        {
            AddParents();
            DevKit.AddAndAssert<RigList, Rig>(Rig);
			DevKit.AddAndAssert<RigList, Rig>(Rig, ErrorCodes.DataObjectUidAlreadyExists);
        }

		#endregion Error -405

        #region Error -406

		[TestMethod]
        public void Rig141Validator_AddToStore_Error_406_Rig_Missing_Parent_Uid()
        {
            AddParents();

            Rig.UidWellbore = null;
            DevKit.AddAndAssert(Rig, ErrorCodes.MissingElementUidForAdd);
        }

		#endregion Error -406

        #region Error -407

		[TestMethod]
        public void Rig141Validator_UpdateInStore_Error_407_Rig_Missing_Witsml_Object_Type()
        {
            AddParents();
            DevKit.AddAndAssert<RigList, Rig>(Rig);
			var response = DevKit.Update<RigList, Rig>(Rig, string.Empty);
            Assert.IsNotNull(response);
            Assert.AreEqual((short)ErrorCodes.MissingWmlTypeIn, response.Result);
        }

		#endregion Error -407

        #region Error -408

		[TestMethod]
        public void Rig141Validator_UpdateInStore_Error_408_Rig_Empty_QueryIn()
        {
			var response = DevKit.UpdateInStore(ObjectTypes.Rig, string.Empty, null, null);
            Assert.IsNotNull(response);
            Assert.AreEqual((short)ErrorCodes.MissingInputTemplate, response.Result);
        }

		#endregion Error -408

        #region Error -409

		[TestMethod]
        public void Rig141Validator_UpdateInStore_Error_409_Rig_QueryIn_Must_Conform_To_Schema()
        {
            AddParents();
            DevKit.AddAndAssert<RigList, Rig>(Rig);

            var nonConformingXml = string.Format(BasicXMLTemplate, Rig.UidWell, Rig.UidWellbore, Rig.Uid,
                $"<name>{Rig.Name}</name><name>{Rig.Name}</name>");

            var response = DevKit.UpdateInStore(ObjectTypes.Rig, nonConformingXml, null, null);
            Assert.AreEqual((short)ErrorCodes.InputTemplateNonConforming, response.Result);
        }

		#endregion Error -409

        #region Error -415

		[TestMethod]
        public void Rig141Validator_UpdateInStore_Error_415_Rig_Update_Without_Specifing_UID()
        {
            AddParents();
            DevKit.AddAndAssert<RigList, Rig>(Rig);
            Rig.Uid = string.Empty;
			DevKit.UpdateAndAssert<RigList, Rig>(Rig, ErrorCodes.DataObjectUidMissing);
        }

		#endregion Error -415

        #region Error -416

		[TestMethod]
        public void Rig141Validator_DeleteFromStore_Error_416_Rig_Delete_With_Empty_UID()
        {

            AddParents();

            var ext1 = DevKit.ExtensionNameValue("Ext-1", "1.0", "m");
            Rig.CommonData = new CommonData
            {
                ExtensionNameValue = new List<ExtensionNameValue>
                {
                    ext1
                }
            };

            DevKit.AddAndAssert(Rig);

            var deleteXml = string.Format(BasicXMLTemplate,Rig.UidWell, Rig.UidWellbore,Rig.Uid,

                "<commonData><extensionNameValue uid=\"\" /></commonData>");

            var results = DevKit.DeleteFromStore(ObjectTypes.Rig, deleteXml, null, null);

            Assert.IsNotNull(results);
            Assert.AreEqual((short)ErrorCodes.EmptyUidSpecified, results.Result);
        }

		#endregion Error -416

        #region Error -418

		[TestMethod]
        public void Rig141Validator_DeleteFromStore_Error_418_Rig_Delete_With_Missing_Uid()
        {

            AddParents();

            var ext1 = DevKit.ExtensionNameValue("Ext-1", "1.0", "m");
            Rig.CommonData = new CommonData
            {
                ExtensionNameValue = new List<ExtensionNameValue>
                {
                    ext1
                }
            };

            DevKit.AddAndAssert(Rig);

            var deleteXml = string.Format(BasicXMLTemplate,Rig.UidWell, Rig.UidWellbore,Rig.Uid,

                "<commonData><extensionNameValue  uid=\"\" /></commonData>");

            var results = DevKit.DeleteFromStore(ObjectTypes.Rig, deleteXml, null, null);

            Assert.IsNotNull(results);
            Assert.AreEqual((short)ErrorCodes.EmptyUidSpecified, results.Result);
        }

		#endregion Error -418

        #region Error -419

		[TestMethod]
        public void Rig141Validator_DeleteFromStore_Error_419_Rig_Deleting_Empty_NonRecurring_Container_Element()
        {

            AddParents();

            var ext1 = DevKit.ExtensionNameValue("Ext-1", "1.0", "m");
            Rig.CommonData = new CommonData
            {
                ExtensionNameValue = new List<ExtensionNameValue>
                {
                    ext1
                }
            };

            DevKit.AddAndAssert(Rig);

            var deleteXml = string.Format(BasicXMLTemplate,Rig.UidWell, Rig.UidWellbore,Rig.Uid,

                "<commonData />");

            var results = DevKit.DeleteFromStore(ObjectTypes.Rig, deleteXml, null, null);

            Assert.IsNotNull(results);
            Assert.AreEqual((short)ErrorCodes.EmptyMandatoryNodeSpecified, results.Result);
        }

		#endregion Error -419

        #region Error -420

		[TestMethod]
        public void Rig141Validator_DeleteFromStore_Error_420_Rig_Specifying_A_Non_Recuring_Element_That_Is_Required()
        {

            AddParents();

            DevKit.AddAndAssert(Rig);

            var deleteXml = string.Format(BasicXMLTemplate,Rig.UidWell, Rig.UidWellbore,Rig.Uid,

                "<name />");
            var results = DevKit.DeleteFromStore(ObjectTypes.Rig, deleteXml, null, null);

            Assert.IsNotNull(results);
            Assert.AreEqual((short)ErrorCodes.EmptyUidSpecified, results.Result);
        }

		#endregion Error -420

        #region Error -433

		[TestMethod]
        public void Rig141Validator_UpdateInStore_Error_433_Rig_Does_Not_Exist()
        {
            AddParents();
			DevKit.UpdateAndAssert<RigList, Rig>(Rig, ErrorCodes.DataObjectNotExist);
        }

		#endregion Error -433

        #region Error -438

		[TestMethod]
        public void Rig141Validator_GetFromStore_Error_438_Rig_Recurring_Elements_Have_Inconsistent_Selection()
        {

            AddParents();

            var ext1 = DevKit.ExtensionNameValue("Ext-1", "1.0", "m");
            var ext2 = DevKit.ExtensionNameValue("Ext-2", "1.0", "m");

            Rig.CommonData = new CommonData
            {
                ExtensionNameValue = new List<ExtensionNameValue>
                {
                    ext1, ext2
                }
            };

            DevKit.AddAndAssert(Rig);

            var queryXml = string.Format(BasicXMLTemplate,Rig.UidWell, Rig.UidWellbore,Rig.Uid,

                "<commonData>" +
                $"<extensionNameValue uid=\"\"><name>Ext-1</name></extensionNameValue>" +
                "<extensionNameValue uid=\"\"><value uom=\"\">1.0</value></extensionNameValue>" +
                "</commonData>");

            var results = DevKit.GetFromStore(ObjectTypes.Rig, queryXml, null, null);

            Assert.IsNotNull(results);
            Assert.AreEqual((short)ErrorCodes.RecurringItemsInconsistentSelection, results.Result);
        }

		#endregion Error -438

        #region Error -439

		[TestMethod]
        public void Rig141Validator_GetFromStore_Error_439_Rig_Recurring_Elements_Has_Empty_Selection_Value()
        {

            AddParents();

            var ext1 = DevKit.ExtensionNameValue("Ext-1", "1.0", "m");
            var ext2 = DevKit.ExtensionNameValue("Ext-2", "1.0", "m");

            Rig.CommonData = new CommonData
            {
                ExtensionNameValue = new List<ExtensionNameValue>
                {
                    ext1, ext2
                }
            };

            DevKit.AddAndAssert(Rig);

            var queryXml = string.Format(BasicXMLTemplate,Rig.UidWell, Rig.UidWellbore,Rig.Uid,

                "<commonData>" +
                $"<extensionNameValue uid=\"\"><name>Ext-1</name></extensionNameValue>" +
                "<extensionNameValue uid=\"\"><name></name></extensionNameValue>" +
                "</commonData>");

            var results = DevKit.GetFromStore(ObjectTypes.Rig, queryXml, null, null);

            Assert.IsNotNull(results);
            Assert.AreEqual((short)ErrorCodes.RecurringItemsEmptySelection, results.Result);
        }

		#endregion Error -439

        #region Error -444

		[TestMethod]
        public void Rig141Validator_UpdateInStore_Error_444_Rig_Updating_More_Than_One_Data_Object()
        {
            AddParents();
            DevKit.AddAndAssert<RigList, Rig>(Rig);

            var updateXml = "<rigs xmlns=\"http://www.witsml.org/schemas/1series\" version=\"1.4.1.1\"><rig uidWell=\"{0}\" uidWellbore=\"{1}\" uid=\"{2}\"></rig><rig uidWell=\"{0}\" uidWellbore=\"{1}\" uid=\"{2}\"></rig></rigs>";
            updateXml = string.Format(updateXml, Rig.UidWell, Rig.UidWellbore, Rig.Uid);

            var response = DevKit.UpdateInStore(ObjectTypes.Rig, updateXml, null, null);
            Assert.AreEqual((short)ErrorCodes.InputTemplateMultipleDataObjects, response.Result);
        }

		#endregion Error -444

        #region Error -445

        [TestMethod]
        public void Rig141Validator_UpdateInStore_Error_445_Rig_Empty_New_Element()
        {

            AddParents();

            var ext1 = DevKit.ExtensionNameValue("Ext-1", "1.0", "m");

            Rig.CommonData = new CommonData
            {
                ExtensionNameValue = new List<ExtensionNameValue>
                {
                    ext1
                }
            };

            DevKit.AddAndAssert(Rig);

            ext1 = DevKit.ExtensionNameValue("Ext-1", string.Empty, string.Empty, PrimitiveType.@double, string.Empty);
            Rig.CommonData = new CommonData
            {
                ExtensionNameValue = new List<ExtensionNameValue>
                {
                    ext1
                }
            };

            DevKit.UpdateAndAssert(Rig, ErrorCodes.EmptyNewElementsOrAttributes);
        }

		#endregion Error -445

        #region Error -448

        [TestMethod]
        public void Rig141Validator_UpdateInStore_Error_448_Rig_Missing_Uid()
        {

            AddParents();

            var ext1 = DevKit.ExtensionNameValue("Ext-1", "1.0", "m");

            Rig.CommonData = new CommonData
            {
                ExtensionNameValue = new List<ExtensionNameValue>
                {
                    ext1
                }
            };

            DevKit.AddAndAssert(Rig);

                        var updateXml = string.Format(BasicXMLTemplate,Rig.UidWell, Rig.UidWellbore,Rig.Uid,

                "<commonData>" +
                $"<extensionNameValue uid=\"\"><value uom=\"ft\" /></extensionNameValue>" +
                "</commonData>");

            var response = DevKit.UpdateInStore(ObjectTypes.Rig, updateXml, null, null);
            Assert.AreEqual((short)ErrorCodes.MissingElementUidForUpdate, response.Result);
        }

		#endregion Error -448

        #region Error -464

        [TestMethod]
        public void Rig141Validator_AddToStore_Error_464_Rig_Uid_Not_Unique()
        {

            AddParents();

            var ext1 = DevKit.ExtensionNameValue("Ext-1", "1.0", "m");
            var ext2 = DevKit.ExtensionNameValue("Ext-1", "1.0", "m");

            Rig.CommonData = new CommonData
            {
                ExtensionNameValue = new List<ExtensionNameValue>
                {
                    ext1, ext2
                }
            };

            DevKit.AddAndAssert(Rig);
        }

        [TestMethod]
        public void Rig141Validator_UpdateInStore_Error_464_Rig_Uid_Not_Unique()
        {

            AddParents();

            var ext1 = DevKit.ExtensionNameValue("Ext-1", "1.0", "m");

            Rig.CommonData = new CommonData
            {
                ExtensionNameValue = new List<ExtensionNameValue>
                {
                    ext1
                }
            };

            DevKit.AddAndAssert(Rig, ErrorCodes.ChildUidNotUnique);

            var ext2 = DevKit.ExtensionNameValue("Ext-1", "1.0", "m");

            Rig.CommonData = new CommonData
            {
                ExtensionNameValue = new List<ExtensionNameValue>
                {
                    ext1, ext2
                }
            };

            DevKit.UpdateAndAssert(Rig, ErrorCodes.ChildUidNotUnique);
        }

		#endregion Error -464

        #region Error -468

		[TestMethod]
        public void Rig141Validator_UpdateInStore_Error_468_Rig_No_Schema_Version_Declared()
        {

            AddParents();
            DevKit.AddAndAssert<RigList, Rig>(Rig);
            var response = DevKit.UpdateInStore(ObjectTypes.Rig, QueryMissingVersion, null, null);
            Assert.AreEqual((short)ErrorCodes.MissingDataSchemaVersion, response.Result);
        }

		#endregion Error -468

        #region Error -478

		[TestMethod]
        public void Rig141Validator_AddToStore_Error_478_Rig_Parent_Uid_Case_Not_Matching()
        {
            Well.Uid = Well.Uid.ToUpper();
            AddParents();
            Rig.UidWell = Well.Uid.ToLower();
            DevKit.AddAndAssert(Rig, ErrorCodes.IncorrectCaseParentUid);
        }

		#endregion Error -478

        #region Error -481

		[TestMethod]
        public void Rig141Validator_AddToStore_Error_481_Rig_Parent_Does_Not_Exist()
        {
            DevKit.AddAndAssert(Rig, ErrorCodes.MissingParentDataObject);
        }

		#endregion Error -481

        #region Error -483

		[TestMethod]
        public void Rig141Validator_UpdateInStore_Error_483_Rig_Update_With_Non_Conforming_Template()
        {
            AddParents();
            DevKit.AddAndAssert<RigList, Rig>(Rig);
            var response = DevKit.UpdateInStore(ObjectTypes.Rig, QueryEmptyRoot, null, null);
            Assert.AreEqual((short)ErrorCodes.UpdateTemplateNonConforming, response.Result);
        }

		#endregion Error -483

        #region Error -484

		[TestMethod]
        public void Rig141Validator_UpdateInStore_Error_484_Rig_Update_Will_Delete_Required_Element()
        {

            AddParents();
            DevKit.AddAndAssert<RigList, Rig>(Rig);

            var nonConformingXml = string.Format(BasicXMLTemplate, Rig.UidWell, Rig.UidWellbore, Rig.Uid,
                $"<name></name>");

            var response = DevKit.UpdateInStore(ObjectTypes.Rig, nonConformingXml, null, null);
            Assert.AreEqual((short)ErrorCodes.MissingRequiredData, response.Result);
        }

		#endregion Error -484

        #region Error -486

		[TestMethod]
        public void Rig141Validator_AddToStore_Error_486_Rig_Data_Object_Types_Dont_Match()
        {

            AddParents();

            var xmlIn = string.Format(BasicXMLTemplate, Rig.UidWell, Rig.UidWellbore, Rig.Uid,
                string.Empty);

            var response = DevKit.AddToStore(ObjectTypes.Well, xmlIn, null, null);
            Assert.AreEqual((short)ErrorCodes.DataObjectTypesDontMatch, response.Result);
        }

		#endregion Error -486

    }
}