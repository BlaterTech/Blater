using System.Collections.Generic;
using System.Linq;

namespace Blater.Extensions;

public static class BlaterIdExtensions
{
    public static BlaterRevisionDictionary ToBlaterRevisionDictionary(this IEnumerable<BlaterId> ids)
    {
        var dict = new BlaterRevisionDictionary();

        foreach (var id in ids)
        {
            if (id.Revisions == null)
            {
                continue;
            }

            dict.Add(id, id.Revisions.Select(x => x.Revision).ToList());
        }

        return dict;
    }
}