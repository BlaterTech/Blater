
using Blater.Resullts;
using OneOf.Types;

namespace Blater.Interfaces;

public interface IBlaterQueue
{
    Task<BlaterResult<Success>> Enqueue(string queue, BaseQueueMessage message);
    Task<BlaterResult<Success>> Enqueue(string queue, IEnumerable<BaseQueueMessage> message);

    Task<BlaterResult<IReadOnlyList<BaseQueueMessage>>> Peek(string queue, int count);

    Task<BlaterResult<IReadOnlyList<BaseQueueMessage>>> Dequeue(string queue, int count, QueueReadOptions readOptions);

    Task<BlaterResult<Success>> Archive(string queue, BaseQueueMessage message);

    Task<BlaterResult<int>> Count(string queue);

    Task<BlaterResult<Success>> Delete(string queue, BaseQueueMessage message);

    #region Queue Management

    /// <summary>
    ///     This will create a queue if it does not exist
    ///     OBS: Publish will create the queue if it does not exist, so this is not necessary
    /// </summary>
    /// <param name="queue"></param>
    /// <returns></returns>
    Task<BlaterResult<Success>> CreateQueue(string queue);

    Task<BlaterResult<Success>> DeleteQueue(string queue);

    #endregion
}