using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace BoilerPlateCrud.Localization
{
    public static class BoilerPlateCrudLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(BoilerPlateCrudConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(BoilerPlateCrudLocalizationConfigurer).GetAssembly(),
                        "BoilerPlateCrud.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
