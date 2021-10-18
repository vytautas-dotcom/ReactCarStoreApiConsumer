

class Stores extends React.Component {
    constructor(props) {
        super(props);
        this.state = { stores: [] };
    }

    componentDidMount() {
        const xhr = new XMLHttpRequest();
        xhr.open('get', this.props.url, true);
        xhr.onload = () => {
            const data = JSON.parse(xhr.responseText);
            console.log(data);
            this.setState({ stores: data });
        };
        xhr.send();
    }

    render() {
        return (
            <div className="Stores">
                <h1>Car Stores</h1>
                <StoreList stores={this.state.stores} />
                {/*<CarList cars={this.state.stores[0]} />*/}
            </div>
            );
    }
}



class StoreList extends React.Component {
    render() {
        return (
            <div className="StoresList" >
                <div>
                    {this.props.stores.map((city, index) => (
                        <div key={index}>
                            <h2>{city.city}</h2>

                            <div>
                                {city.carList.map((car, i) => (
                                    <p key={i}>
                                        {car.name} named {car.price}
                                    </p>
                                ))}
                            </div>
                        </div>
                    ))}
                </div>
            </div>
            );
    }
}

//class CarList extends React.Component {
//    render() {
//        const table = this.props.cars.map(cars => (
//            cars.carList.map(el => (
//                <table>
//                    <tr>
//                        <th>Name</th>
//                        <th>DateRelease</th>
//                        <th>Price</th>
//                        <th>Remark</th>
//                        <th>IsInStore</th>
//                    </tr>
//                    <tr>
//                        <td>{el.name}</td>
//                        <td>{el.dateRelease}</td>
//                        <td>{el.price}</td>
//                        <td>{el.remark}</td>
//                        <td>{el.isInStore}</td>
//                    </tr>
//                </table>
//                ))
//        ));
//        return (
//            {table}
//        );
//    }
//}


ReactDOM.render(<Stores url="/stores"/>, document.getElementById('content'));

