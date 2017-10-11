var RepairsRow = React.createClass({
    displayName: 'RepairsRow',
    render: function () {
        return (
            <tr>
                <td>{this.props.item.ID}</td>
                <td>{this.props.item.Tenant_ID}</td>
                <td>{this.props.item.Worker_ID}</td>
                <td>{this.props.item.Complex_ID}</td>
                <td>{this.props.item.Issue}</td>
                <td>{this.props.item.IssueDetails}</td>
                <td>{this.props.item.Status}</td>
            </tr>

        );
    }
});

var RepairsTable = React.createClass({
    displayName: "RepairsTable",
    getInitialState: function () {

        return {
            result: []
        }
    },
    componentWillMount: function () {

        var xhr = new XMLHttpRequest();
        xhr.open('get', this.props.url, true);
        xhr.onload = function () {
            var response = JSON.parse(xhr.responseText);

            this.setState({ result: response });

        }.bind(this);
        xhr.send();
    },
    render: function () {
        var rows = [];
        this.state.result.forEach(function (item) {
            rows.push(<EmployeeRow key={item.ID} item={item} />);
        });
        return (<table className="table">
            <thead>
                <tr>
                    <th>ID</th>
                    <th>Tenant ID</th>
                    <th>Worker ID</th>
                    <th>Complex ID</th>
                    <th>Issue</th>
                    <th>Issue Details</th>
                    <th>Status</th>
                </tr>
            </thead>

            <tbody>
                {rows}
            </tbody>

        </table>);
    }

});

ReactDOM.render(<EmployeeTable url="api/Repairs/GetRepairs" />,
    document.getElementById('grid'))











