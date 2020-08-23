import React, { Component } from 'react';
import { Table } from 'reactstrap';

export class GradeSummary extends Component {
  static displayName = GradeSummary.name;

  constructor(props) {
    super(props);
    this.state = { summaryGrades: [], loading: true };
  }

  componentDidMount() {
    this.populateSummaryData();
  }

   renderGradesTable = summaryGrades => {
    return (
      <Table striped>
        <thead>
          <tr>
            <th>Category</th>
            <th>Year</th>            
            <th>Average Number Level 2</th>           
          </tr>
        </thead>
        <tbody>
          {summaryGrades.map(gradescore =>
            <tr key={new Date()}>
              <td>{gradescore.category}</td>
              <td>{gradescore.year}</td>              
              <td>{gradescore.numberLevel2Avg.toFixed(3)}</td>              
            </tr>
          )}
        </tbody>
      </Table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : this.renderGradesTable(this.state.summaryGrades);

    return (
      <div>
        <h3 id="tabelLabel" >Summary</h3>
        {contents}
      </div>
    );
  }

  async populateSummaryData() {
    const response = await fetch('api/NyGrade/Summary');
    const data = await response.json();
    this.setState({ summaryGrades: data, loading: false });
  }
}
