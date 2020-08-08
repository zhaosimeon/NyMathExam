import React, { Component } from 'react';

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
      <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>Category</th>
            <th>Year</th>            
            <th>Number Tested Average</th>           
          </tr>
        </thead>
        <tbody>
          {summaryGrades.map(gradescore =>
            <tr key={new Date()}>
              <td>{gradescore.category}</td>
              <td>{gradescore.year}</td>              
              <td>{gradescore.numberTestedAvg.toFixed(3)}</td>              
            </tr>
          )}
        </tbody>
      </table>
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
