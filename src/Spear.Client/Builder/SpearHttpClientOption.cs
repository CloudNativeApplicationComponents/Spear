using System;
using System.Diagnostics.CodeAnalysis;

namespace Spear.Client.Builder
{
    public class SpearHttpClientOption
    {
        [DisallowNull]
        [NotNull]
        public Uri? BaseAddress { get; set; }
    }
}
