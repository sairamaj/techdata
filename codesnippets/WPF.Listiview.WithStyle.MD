### List view custom cells

```xml
<ListView ItemsSource="{Binding Source}">
			<ListView.View>
				<GridView
					views:GridViewColumns.HeaderTextMember="Column" views:GridViewColumns.DisplayMemberMember="DisplayMember" ColumnHeaderContainerStyle="{StaticResource HeaderStyle}">

					<GridViewColumn  DisplayMemberBinding="{Binding Status}" Width="200" HeaderTemplate="{StaticResource ColumnHeader}">
						<GridViewColumnHeader Tag="Status" Content="Status"  />
					</GridViewColumn>

				</GridView>
			</ListView.View>

			<ListView.ItemContainerStyle>
				<Style TargetType="{x:Type ListViewItem}">
					<Setter Property="HorizontalContentAlignment" Value="Stretch"></Setter>
					<Style.Triggers>
						<DataTrigger Binding="{Binding Path=Status}" Value="Success">
							<Setter Property="ListViewItem.Foreground" Value="Green" />
						</DataTrigger>
					</Style.Triggers>
				</Style>
			</ListView.ItemContainerStyle>
```