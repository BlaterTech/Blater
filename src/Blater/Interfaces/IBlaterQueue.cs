

using Blater.Results;

namespace Blater.Interfaces;

public interface IBlaterQueue
{
    Task<BlaterResult> PublishQueueMessage(string queue, BaseQueueMessage message);
    Task<BlaterResult> PublishQueueMessages(string queue, IEnumerable<BaseQueueMessage> message);

    Task<BlaterResult<IReadOnlyList<BaseQueueMessage>>> PeekQueueMessage(string queue, int count);

    Task<BlaterResult<IReadOnlyList<BaseQueueMessage>>> ReadQueueMessages(string queue, int count, QueueReadOptions readOptions);

    Task<BlaterResult> ArchiveQueueMessage(string queue, BaseQueueMessage message);

    Task<BlaterResult<int>> CountQueueMessages();

    Task<BlaterResult> DeleteQueueMessage(string queue, BaseQueueMessage message);

    #region Queue Management

    /// <summary>
    ///     This will create a queue if it does not exist
    ///     OBS: Publish will create the queue if it does not exist, so this is not necessary
    /// </summary>
    /// <param name="queue"></param>
    /// <returns></returns>
    Task<BlaterResult> CreateQueue(string queue);

    Task<BlaterResult> DeleteQueue(string queue);

    #endregion
}