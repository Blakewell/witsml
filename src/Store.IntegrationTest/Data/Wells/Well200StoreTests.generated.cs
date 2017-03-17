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

using Energistics.DataAccess;
using Energistics.DataAccess.WITSML200;
using Energistics.DataAccess.WITSML200.ComponentSchemas;
using Energistics.DataAccess.WITSML200.ReferenceData;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PDS.WITSMLstudio.Store.Data.Wells
{
    [TestClass]
    public partial class Well200StoreTests : Well200TestBase
    {
        partial void BeforeEachTest();

        partial void AfterEachTest();

        protected override void OnTestSetUp()
        {
            BeforeEachTest();
        }

        protected override void OnTestCleanUp()
        {
            AfterEachTest();
        }

        [TestMethod]
        public void Well200DataAdapter_GetFromStore_Can_Get_Well()
        {
            AddParents();
            DevKit.AddAndAssert(Well);
            DevKit.GetAndAssert(Well);
       }

        [TestMethod]
        public void Well200DataAdapter_AddToStore_Can_Add_Well()
        {
            AddParents();
            DevKit.AddAndAssert(Well);
        }

        [TestMethod]
        public void Well200DataAdapter_UpdateInStore_Can_Update_Well()
        {
            AddParents();
            DevKit.AddAndAssert(Well);
            DevKit.UpdateAndAssert(Well);
            DevKit.GetAndAssert(Well);
        }

        [TestMethod]
        public void Well200DataAdapter_DeleteFromStore_Can_Delete_Well()
        {
            AddParents();
            DevKit.AddAndAssert(Well);
            DevKit.DeleteAndAssert(Well);
            DevKit.GetAndAssert(Well, isNotNull: false);
        }
    }
}