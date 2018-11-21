### List view custom cells

```xml
<UserControl.Resources>
		<Style x:Key="DataHeaderStyle" TargetType="{x:Type GridViewColumnHeader}">
			<Setter Property="Visibility" Value="Collapsed" />
		</Style>
	</UserControl.Resources>
	<Grid Margin="0,20,0,0">
		<StackPanel>
			<TextBlock Text="Cores" FontWeight="Bold"/>
			<ListView ItemsSource="{Binding Data}" BorderThickness="0">
				<ListView.View >
					<GridView ColumnHeaderContainerStyle="{StaticResource DataHeaderStyle}">
						<GridViewColumn>
							<GridViewColumn.CellTemplate>
								<DataTemplate>
									<StackPanel Orientation="Horizontal">
										<CheckBox />
										<TextBlock  Text="{Binding}" Margin="3,0,0,0"/>
									</StackPanel>
								</DataTemplate>
							</GridViewColumn.CellTemplate>
						</GridViewColumn>
					</GridView>
				</ListView.View>
			</ListView>
		</StackPanel>
	</Grid>
```