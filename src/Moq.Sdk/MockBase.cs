﻿#region Apache Licensed
/*
 Copyright 2013 Clarius Consulting, Daniel Cazzulino

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

     http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/
#endregion

namespace Moq.Sdk
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class MockBase : IMock
    {
        private object defaultValue;
        private bool callBase;

        public IInvocation LastCall { get; private set; }

        public MockBase(object defaultValue = null, bool callBase = false)
        {
            this.defaultValue = defaultValue;
            this.callBase = callBase;
        }

        public void Invoke(IInvocation invocation)
        {
            this.LastCall = invocation;
            if (callBase)
                invocation.InvokeBase();
            else
                invocation.ReturnValue = this.defaultValue;
        }
    }
}