// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Reflection;
using System.Reflection.Emit;
using Xunit;

namespace System.Reflection.Emit.Tests
{
    public class GenericTypeParameterBuilderMakeArrayType
    {
        [Fact]
        public void PosTest1()
        {
            AssemblyName myAsmName = new AssemblyName("GenericEmitExample1");
            AssemblyBuilder myAssembly = AssemblyBuilder.DefineDynamicAssembly(myAsmName, AssemblyBuilderAccess.Run);
            ModuleBuilder myModule = TestLibrary.Utilities.GetModuleBuilder(myAssembly, myAsmName.Name);

            Type baseType = typeof(ExampleBase);

            TypeBuilder myType = myModule.DefineType("Sample", TypeAttributes.Public);

            string[] typeParamNames = { "TFirst" };
            GenericTypeParameterBuilder[] typeParams = myType.DefineGenericParameters(typeParamNames);

            GenericTypeParameterBuilder TFirst = typeParams[0];
            string expectedValue = "TFirst[*]";
            string actualValue;

            Type type = TFirst.MakeArrayType(1);
            actualValue = type.Name;

            Assert.Equal(expectedValue, actualValue);
        }

        [Fact]
        public void PosTest2()
        {
            AssemblyName myAsmName = new AssemblyName("GenericEmitExample1");
            AssemblyBuilder myAssembly = AssemblyBuilder.DefineDynamicAssembly(myAsmName, AssemblyBuilderAccess.Run);
            ModuleBuilder myModule = TestLibrary.Utilities.GetModuleBuilder(myAssembly, myAsmName.Name);

            Type baseType = typeof(ExampleBase);

            TypeBuilder myType = myModule.DefineType("Sample", TypeAttributes.Public);

            string[] typeParamNames = { "TFirst" };
            GenericTypeParameterBuilder[] typeParams = myType.DefineGenericParameters(typeParamNames);

            GenericTypeParameterBuilder TFirst = typeParams[0];

            string expectedValue = "TFirst[,]";
            string actualValue;

            Type type = TFirst.MakeArrayType(2);
            actualValue = type.Name;

            Assert.Equal(expectedValue, actualValue);
        }

        [Fact]
        public void NegTest1()
        {
            AssemblyName myAsmName = new AssemblyName("GenericEmitExample1");
            AssemblyBuilder myAssembly = AssemblyBuilder.DefineDynamicAssembly(myAsmName, AssemblyBuilderAccess.Run);
            ModuleBuilder myModule = TestLibrary.Utilities.GetModuleBuilder(myAssembly, myAsmName.Name);

            Type baseType = typeof(ExampleBase);

            TypeBuilder myType = myModule.DefineType("Sample", TypeAttributes.Public);

            string[] typeParamNames = { "TFirst" };
            GenericTypeParameterBuilder[] typeParams = myType.DefineGenericParameters(typeParamNames);

            GenericTypeParameterBuilder TFirst = typeParams[0];
            Assert.Throws<IndexOutOfRangeException>(() => { Type type = TFirst.MakeArrayType(0); });
        }

        [Fact]
        public void NegTest2()
        {
            AssemblyName myAsmName = new AssemblyName("GenericEmitExample1");
            AssemblyBuilder myAssembly = AssemblyBuilder.DefineDynamicAssembly(myAsmName, AssemblyBuilderAccess.Run);
            ModuleBuilder myModule = TestLibrary.Utilities.GetModuleBuilder(myAssembly, myAsmName.Name);

            Type baseType = typeof(ExampleBase);

            TypeBuilder myType = myModule.DefineType("Sample", TypeAttributes.Public);

            string[] typeParamNames = { "TFirst" };
            GenericTypeParameterBuilder[] typeParams = myType.DefineGenericParameters(typeParamNames);

            GenericTypeParameterBuilder TFirst = typeParams[0];
            Assert.Throws<IndexOutOfRangeException>(() => { Type type = TFirst.MakeArrayType(-1); });
        }
    }
}
