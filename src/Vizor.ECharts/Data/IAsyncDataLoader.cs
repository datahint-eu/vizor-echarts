namespace Vizor.ECharts.Data;

public interface IAsyncDataLoader<TData>
{
	Task LoadDataAsync(IList<TData> items);
}
