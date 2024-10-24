﻿using System.Text;

namespace LightResults.Extensions.GeneratedIdentifier.Common;

/// <summary>Provides extension methods for working with declarations.</summary>
internal static class DeclarationExtensions
{
    /// <summary>Converts a list of declarations to their corresponding namespace.</summary>
    /// <param name="declarations">The list of declarations to convert.</param>
    /// <returns>The namespace represented by the declarations.</returns>
    public static string ToNamespace(this EquatableImmutableArray<Declaration> declarations)
    {
        var builder = new StringBuilder();

        for (var index = 0; index < declarations.Count; index++)
        {
            var declaration = declarations[index];
            if (declaration.Type != DeclarationType.Namespace)
                continue;

            if (builder.Length > 0)
                builder.Append('.');
            builder.Append(declaration.Name);
        }

        return builder.ToString();
    }

    /// <summary>Converts a list of declarations to their fully qualified name.</summary>
    /// <param name="declarations">The list of declarations to convert.</param>
    /// <returns>The fully qualified name represented by the declarations.</returns>
    public static string ToFullyQualifiedName(this EquatableImmutableArray<Declaration> declarations)
    {
        var builder = new StringBuilder();

        for (var index = 0; index < declarations.Count; index++)
        {
            var declaration = declarations[index];

            if (builder.Length > 0)
                builder.Append('.');
            builder.Append(declaration.Name);

            if (declaration.GenericParameters.Count == 0)
                continue;

            builder.Append('`');
            builder.Append(declaration.GenericParameters.Count);
        }

        return builder.ToString();
    }
}
