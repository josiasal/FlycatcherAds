using FlycatcherAds.Parameters;

namespace FlycatcherAds.Core.QueryGenerators
{
    public interface IMediaLibraryQueryGenerator
    {
        string GetMediaLibraryQuery(IGetMediaLibraryParameters parameters);
    }
}
