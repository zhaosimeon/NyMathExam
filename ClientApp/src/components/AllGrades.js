import React, { Component } from 'react';
import { Table } from 'reactstrap';

export class AllGrades extends Component {
  static displayName = AllGrades.name;

  constructor(props) {
    super(props);
    this.state = { gradeScores: [], loading: true };
  }

  componentDidMount() {
    this.populateGradeScoreData();
  }

   renderGradesTable = gradeScores => {
    return (
      <Table striped dark>
        <thead>
          <tr>
            <th>Grade</th>
            <th>Year</th>
            <th>Category</th>
            <th>Number Tested</th>
            <th>Mean Scale Score</th>
            <th># Level 1</th>
            <th>% Level 1</th>
            <th># Level 2</th>
            <th>% Level 2</th>
            <th># Level 3</th>
            <th>% Level 3</th>
            <th># Level 4</th>
            <th>% Level 4</th>
            <th># Level 3+4</th>
            <th>% Level 3+4</th>
          </tr>
        </thead>
        <tbody>
          {gradeScores.map(gradescore =>
            <tr key={new Date()} scope="row">
              <td>{gradescore.grade}</td>
              <td>{gradescore.year}</td>
              <td>{gradescore.category}</td>
              <td>{gradescore.numberTested}</td>
              <td>{gradescore.meanScaleScore}</td>
              <td>{gradescore.numberLevel1}</td>
              <td>{gradescore.percentLevel1}</td>
              <td>{gradescore.numberLevel2}</td>
              <td>{gradescore.percentLevel2}</td>
              <td>{gradescore.numberLevel3}</td>
              <td>{gradescore.percentLevel3}</td>
              <td>{gradescore.numberLevel4}</td>
              <td>{gradescore.percentLevel4}</td>
              <td>{gradescore.numberLevel3p4}</td>
              <td>{gradescore.percentLevel3p4}</td>
            </tr>
          )}
        </tbody>
      </Table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : this.renderGradesTable(this.state.gradeScores);

    return (
      <div>
        <h3 id="tabelLabel" >All Grades</h3>
        {contents}
      </div>
    );
  }

  async populateGradeScoreData() {
    const response = await fetch('api/NyGrade');
    const data = await response.json();
    this.setState({ gradeScores: data, loading: false });
  }
}
