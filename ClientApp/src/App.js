import React, { Component } from 'react';
import { AllGrades } from './components/AllGrades';
import { GradeSummary} from './components/GradeSummary';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import './custom.css'
export default class App extends Component {
  static displayName = App.name;

  render() {
    return (
      <Layout>
      <Route exact path='/' component={AllGrades} />
      <Route path='/Summary' component={GradeSummary} />
    </Layout>
    );
  }
}
