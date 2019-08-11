## Making button enable disable during loading

### View
```xml
	<UserControl.Resources>
		<Style x:Key="LoadingButtonStyle">
			<Setter Property="Control.IsEnabled" Value="True" />
			<Setter Property="Button.Content" Value="Load" />
			<Style.Triggers>
				<DataTrigger Binding="{Binding IsLoading}" Value="True">
					<Setter Property="Control.IsEnabled" Value="False" />
					<Setter Property="Button.Content" Value="Loading" />
				</DataTrigger>
			</Style.Triggers>
		</Style>
	</UserControl.Resources>
```

### Code
```csharp
IsLoading = true
OnPropertyChanged(()=> this.IsLoading)
// async process here
IsLoading = false
OnPropertyChanged(()=> this.IsLoading)
```