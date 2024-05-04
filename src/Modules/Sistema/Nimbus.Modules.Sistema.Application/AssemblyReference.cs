// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="AssemblyReference.cs" company="Néctar Informática Ltda">
//    Nimbus
//  </copyright>
//  <summary>
//    Defines the AssemblyReference.cs type.
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace Nimbus.Modules.Sistema.Application;

using System.Reflection;

public static class AssemblyReference
{
    #region Fields

    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;

    #endregion
}