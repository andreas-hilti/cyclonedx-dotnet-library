// This file is part of CycloneDX Library for .NET
//
// Licensed under the Apache License, Version 2.0 (the “License”);
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an “AS IS” BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// SPDX-License-Identifier: Apache-2.0
// Copyright (c) OWASP Foundation. All Rights Reserved.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace CycloneDX.Models.v1_2
{
    [XmlType("dependency")]
    public class Dependency
    {
        [XmlAttribute("ref")]
        public string Ref { get; set; }

        [XmlElement("dependency")]
        public List<Dependency> Dependencies { get; set; }

        public Dependency() {}

        public Dependency(v1_3.Dependency dependency)
        {
            Ref = dependency.Ref;
            if (dependency.Dependencies != null)
            {
                Dependencies = new List<Dependency>();
                foreach (var dep in dependency.Dependencies)
                {
                    Dependencies.Add(new Dependency(dep));
                }
            }
        }
    }
}