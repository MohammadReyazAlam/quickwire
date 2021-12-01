﻿// Copyright 2021 Flavien Charlon
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

using Quickwire.Attributes;

namespace Quickwire.Tests
{
    public static class TestObjects
    {
        public class Dependency
        { }

        public record ConstructorInjection(Dependency Dependency1, string Dependency2);

        public class MultipleConstructors
        {
            public MultipleConstructors(Dependency dependency1, string dependency2)
            {
                Dependency1 = dependency1;
                Dependency2 = dependency2;
            }

            [ServiceConstructor]
            public MultipleConstructors(Dependency dependency1)
            {
                Dependency1 = dependency1;
                Dependency2 = "Second Constructor";
            }

            public Dependency Dependency1 { get; }

            public string Dependency2 { get; }
        }

        public class NoSetterInjection
        {
            public Dependency DependencyGet { get; }

            public Dependency DependencyGetSet { get; set; }

            public Dependency DependencyGetInit { get; init; }
        }

        public class SetterInjection
        {
            [InjectService]
            public Dependency DependencyGetSet { get; set; }
        }

        [InjectAllInitOnlyProperties]
        public class InitOnlySetterInjection
        {
            public Dependency DependencyGet { get; }

            public Dependency DependencyGetSet { get; set; }

            public Dependency DependencyGetInit { get; init; }
        }
    }
}