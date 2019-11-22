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

### Multi style.
```xml
            <ListView.ItemContainerStyle>
                <Style TargetType="{x:Type ListViewItem}">
                    <Style.Triggers>
                        <MultiDataTrigger>
                            <MultiDataTrigger.Conditions>
                                <Condition Binding="{Binding Prop1}" Value="Yes" />
                                <Condition Binding="{Binding Prop2}" Value="Yes" />
                            </MultiDataTrigger.Conditions>
                            <Setter Property="ListViewItem.Foreground" Value="DarkGreen" />
                            <Setter Property="ListViewItem.FontWeight" Value="Bold" />
                        </MultiDataTrigger>
                        <MultiDataTrigger>
                            <MultiDataTrigger.Conditions>
                                <Condition Binding="{Binding Prop1}" Value="Yes" />
                                <Condition Binding="{Binding Prop2}" Value="No" />
                            </MultiDataTrigger.Conditions>
                            <Setter Property="ListViewItem.Foreground" Value="Green" />
                        </MultiDataTrigger>
                        <MultiDataTrigger>
                            <MultiDataTrigger.Conditions>
                                <Condition Binding="{Binding Prop1}" Value="No" />
                                <Condition Binding="{Binding Prop2}" Value="Yes" />
                            </MultiDataTrigger.Conditions>
                            <Setter Property="ListViewItem.Foreground" Value="LightCoral" />
                        </MultiDataTrigger>
                        <MultiDataTrigger>
                            <MultiDataTrigger.Conditions>
                                <Condition Binding="{Binding Prop1}" Value="No" />
                                <Condition Binding="{Binding Prop2}" Value="No" />
                            </MultiDataTrigger.Conditions>
                            <Setter Property="ListViewItem.Foreground" Value="Red" />
                        </MultiDataTrigger>
                    </Style.Triggers>
                </Style>
            </ListView.ItemContainerStyle>

```