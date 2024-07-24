using Blater.Options;
using Blater.Results;

namespace Blater.Interfaces;

public interface IBlaterQueue
{
    Task<bool> Enqueue(string queue, BaseQueueMessage message);
    Task<bool> Enqueue(string queue, IEnumerable<BaseQueueMessage> message);

    Task<BlaterResult<IReadOnlyList<BaseQueueMessage>>> Peek(string queue, int count);

    Task<BlaterResult<IReadOnlyList<BaseQueueMessage>>> Dequeue(string queue, int count, QueueReadOptions readOptions);

    Task<bool> Archive(string queue, BaseQueueMessage message);

    Task<BlaterResult<int>> Count(string queue);

    Task<bool> Delete(string queue, BaseQueueMessage message);

    #region Queue Management

    /// <summary>
    ///     This will create a queue if it does not exist
    ///     OBS: Publish will create the queue if it does not exist, so this is not necessary
    /// </summary>
    /// <param name="queue"></param>
    /// <returns></returns>
    Task<bool> CreateQueue(string queue);

    Task<bool> DeleteQueue(string queue);

    #endregion
}