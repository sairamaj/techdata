### List view without header and border

```xml
<UserControl.Resources>
		<Style x:Key="DataHeaderStyle" TargetType="{x:Type GridViewColumnHeader}">
			<Setter Property="Visibility" Value="Collapsed" />
		</Style>
	</UserControl.Resources>
	<Grid Margin="0,20,0,0">
		<StackPanel>
			<TextBlock Text="Data" FontWeight="Bold"/>
			<ListView ItemsSource="{Binding Data}" BorderThickness="0">
				<ListView.View >
					<GridView ColumnHeaderContainerStyle="{StaticResource DataHeaderStyle}">
						<GridViewColumn  DisplayMemberBinding="{Binding}">
							<GridViewColumnHeader Tag="Name" Content="Name"/>
						</GridViewColumn>
					</GridView>
				</ListView.View>
			</ListView>
		</StackPanel>
	</Grid>
```