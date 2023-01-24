using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace ActiveDirectoryTest.Localization
{
    public static class ActiveDirectoryTestLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(ActiveDirectoryTestConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(ActiveDirectoryTestLocalizationConfigurer).GetAssembly(),
                        "ActiveDirectoryTest.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
