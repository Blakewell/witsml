//----------------------------------------------------------------------- 
// PDS WITSMLstudio Store, 2017.1
//
// Copyright 2017 Petrotechnical Data Systems
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

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Energistics.Common;
using Energistics.DataAccess;
using Energistics.DataAccess.WITSML200;
using Energistics.DataAccess.WITSML200.ComponentSchemas;
using Energistics.DataAccess.WITSML200.ReferenceData;
using Energistics.Datatypes;
using Energistics.Protocol;
using Energistics.Protocol.Core;
using Energistics.Protocol.Discovery;
using Energistics.Protocol.Store;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PDS.WITSMLstudio.Store.Data.DataAssuranceRecords
{
    [TestClass]
    public partial class DataAssuranceRecord200EtpTests : DataAssuranceRecord200TestBase
    {
        partial void BeforeEachTest();

        partial void AfterEachTest();

        protected override void OnTestSetUp()
        {
            EtpSetUp(DevKit.Container);
            BeforeEachTest();
            _server.Start();
        }

        protected override void OnTestCleanUp()
        {
            _server?.Stop();
            EtpCleanUp();
            AfterEachTest();
        }

        [TestMethod]
        public void DataAssuranceRecord200_Ensure_Creates_DataAssuranceRecord_With_Default_Values()
        {

            DevKit.EnsureAndAssert(DataAssuranceRecord);

        }

        [TestMethod]
        public async Task DataAssuranceRecord200_GetResources_Can_Get_All_DataAssuranceRecord_Resources()
        {
            AddParents();

            DevKit.AddAndAssert(DataAssuranceRecord);

            await RequestSessionAndAssert();

            var uri = DataAssuranceRecord.GetUri();
            var parentUri = uri.Parent;

            var folderUri = parentUri.Append(uri.ObjectType);
            await GetResourcesAndAssert(folderUri);
        }

        [TestMethod]
        public async Task DataAssuranceRecord200_PutObject_Can_Add_DataAssuranceRecord()
        {
            AddParents();
            await RequestSessionAndAssert();

            var handler = _client.Handler<IStoreCustomer>();
            var uri = DataAssuranceRecord.GetUri();

            var dataObject = CreateDataObject(uri, DataAssuranceRecord);

            // Get Object
            var args = await GetAndAssert(handler, uri);

            // Check for message flag indicating No Data
            Assert.IsNotNull(args?.Header);
            Assert.AreEqual((int)MessageFlags.NoData, args.Header.MessageFlags);

            // Put Object
            await PutAndAssert(handler, dataObject);

            // Get Object
            args = await GetAndAssert(handler, uri);

            // Check Data Object XML
            Assert.IsNotNull(args?.Message.DataObject);
            var xml = args.Message.DataObject.GetString();

            var result = Parse<DataAssuranceRecord>(xml);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task DataAssuranceRecord200_PutObject_Can_Update_DataAssuranceRecord()
        {
            AddParents();
            await RequestSessionAndAssert();

            var handler = _client.Handler<IStoreCustomer>();
            var uri = DataAssuranceRecord.GetUri();

            // Add a ExtensionNameValue to Data Object
            var envName = "TestPutObject";
            var env = DevKit.ExtensionNameValue(envName, envName);
            DataAssuranceRecord.ExtensionNameValue = new List<ExtensionNameValue>() {env};

            var dataObject = CreateDataObject(uri, DataAssuranceRecord);

            // Get Object
            var args = await GetAndAssert(handler, uri);

            // Check for message flag indicating No Data
            Assert.IsNotNull(args?.Header);
            Assert.AreEqual((int)MessageFlags.NoData, args.Header.MessageFlags);

            // Put Object for Add
            await PutAndAssert(handler, dataObject);

            // Get Added Object
            args = await GetAndAssert(handler, uri);

            // Check Added Data Object XML
            Assert.IsNotNull(args?.Message.DataObject);
            var xml = args.Message.DataObject.GetString();

            var result = Parse<DataAssuranceRecord>(xml);

            Assert.IsNotNull(result);

            Assert.IsNotNull(result.ExtensionNameValue.FirstOrDefault(e => e.Name.Equals(envName)));

            // Remove Comment from Data Object
            result.ExtensionNameValue.Clear();

            var updateDataObject = CreateDataObject(uri, result);

            // Put Object for Update
            await PutAndAssert(handler, updateDataObject);

            // Get Updated Object
            args = await GetAndAssert(handler, uri);

            // Check Added Data Object XML
            Assert.IsNotNull(args?.Message.DataObject);
            var updateXml = args.Message.DataObject.GetString();

            result = Parse<DataAssuranceRecord>(updateXml);

            Assert.IsNotNull(result);

            // Test Data Object overwrite

            Assert.IsNull(result.ExtensionNameValue.FirstOrDefault(e => e.Name.Equals(envName)));

        }

        [TestMethod]
        public async Task DataAssuranceRecord200_DeleteObject_Can_Delete_DataAssuranceRecord()
        {
            AddParents();
            await RequestSessionAndAssert();

            var handler = _client.Handler<IStoreCustomer>();
            var uri = DataAssuranceRecord.GetUri();

            var dataObject = CreateDataObject(uri, DataAssuranceRecord);

            // Get Object
            var args = await GetAndAssert(handler, uri);

            // Check for message flag indicating No Data
            Assert.IsNotNull(args?.Header);
            Assert.AreEqual((int)MessageFlags.NoData, args.Header.MessageFlags);

            // Put Object
            await PutAndAssert(handler, dataObject);

            // Get Object
            args = await GetAndAssert(handler, uri);

            // Check Data Object XML
            Assert.IsNotNull(args?.Message.DataObject);
            var xml = args.Message.DataObject.GetString();

            var result = Parse<DataAssuranceRecord>(xml);

            Assert.IsNotNull(result);

            // Delete Object
            await DeleteAndAssert(handler, uri);

            // Get Object
            args = await GetAndAssert(handler, uri);

            // Check Data Object doesn't exist
            Assert.AreEqual(0, args?.Message?.DataObject?.Data?.Length ?? 0);
        }
    }
}