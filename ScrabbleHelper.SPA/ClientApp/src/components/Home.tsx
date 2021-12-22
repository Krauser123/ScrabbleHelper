import React, { Component } from 'react';
import ReactHtmlParser from 'react-html-parser';

interface HomeProps {

}

interface HomeState {
  value: string;
  wordsToDrawHTML: string;
  mainContainerClass: string;
}

export class Home extends Component<HomeProps, HomeState> {
  static displayName = Home.name;

  constructor(props: HomeProps) {
    super(props);
    this.state = { value: "", wordsToDrawHTML: "", mainContainerClass: "mainContainer" };

    this.handleChange = this.handleChange.bind(this);
    this.getWords = this.getWords.bind(this);
  }

  async getWords(event: any) {
    const response = await fetch('ScrabbleHelperWords?letters=' + this.state.value, {
      headers: {
        'Content-Type': 'application/json',
        'Accept': 'application/json'
      }
    });

    const data = await response.json();

    this.drawItems(data);
  }

  drawItems(response) {
    let partialHTML = "<div class='all'>";

    for (let key in response) {

      let value = response[key];
      var splitted = value.split("");
      partialHTML += "<div class='word' score='" + key + "'>";      
      for (let key in splitted) {
        let letter = splitted[key];
        partialHTML += "<div class='tile' data-letter='" + letter + "'></div>";
      }
      partialHTML += "</div>";
    }
    partialHTML += "</div>";
    this.setState({ mainContainerClass: "mainContainerUp", wordsToDrawHTML: partialHTML });
  }

  handleChange(event) {
    this.setState({ value: event.target.value });
  }

  render() {
    return (
      <div className={this.state.mainContainerClass}>
        <div className="rackContainer">
          <div className="rack">
            <div className="tile" data-letter="s">
            </div>
            <div className="tile" data-letter="c">
            </div>
            <div className="tile" data-letter="r">
            </div>
            <div className="tile" data-letter="a">
            </div>
            <div className="tile" data-letter="b">
            </div>
            <div className="tile" data-letter="b">
            </div>
            <div className="tile" data-letter="l">
            </div>
            <div className="tile" data-letter="e">
            </div>

            <div className="tile">
            </div>

            <div className="tile" data-letter="h">
            </div>
            <div className="tile" data-letter="e">
            </div>
            <div className="tile" data-letter="l">
            </div>
            <div className="tile" data-letter="p">
            </div>
            <div className="tile" data-letter="e">
            </div>
            <div className="tile" data-letter="r">
            </div>
          </div>
        </div>

        <div className="formContainer">
          <form className="mainForm">
            <label className="labelLetters">
              Letters:
              </label>
            <input className="inputLetters" value={this.state.value} onChange={this.handleChange} type="text" name="name" />

            <input className="btn-primary" type="button" onClick={this.getWords} value="Submit" />
          </form>
        </div>

        <div className="resultContainer">
          {ReactHtmlParser(this.state.wordsToDrawHTML)}

        </div>

      </div>
    );
  }
}
