// Copyright 2004-2008 Castle Project - http://www.castleproject.org/
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

namespace Castle.Services.Security
{
    using System;
    using System.Security.Principal;

    /// <summary>
	/// Summary description for DenyPolicy.
	/// </summary>
	public class DenyPolicy : IPolicy
	{
        String[] _roles;
        IPrincipal _principal;

        public DenyPolicy(String[] roles, IPrincipal principal)
        {
            this._roles = roles;
            this._principal = principal;
        }

        #region IPolicy Members

        public bool Evaluate()
        {
            bool result = true;
            foreach(String role in this._roles)
            {
                if(this._principal.IsInRole(role))
                {
                    result = false;
                    break;
                }
            }
            return result;
        }

        #endregion
    }
}
