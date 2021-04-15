import React, { useState, useEffect } from "react";
import { connect } from "react-redux";
import * as actions from "../actions/dQuestion";
import { Grid, Paper, withStyles,  Button, TextField, Checkbox } from "@material-ui/core";
import DQuestionForm from "./dQuestionForm";

const styles = theme => ({
    root: {
        "& .MuiTableCell-head": {
            fontSize: "1.25rem"
        }
    },
    paper: {
        margin: theme.spacing(2),
        padding: theme.spacing(2)
    }
})

let index = -1;
let answer1 = "";
let answer2 = "";
let answer3 = "";
let answer4 = "";

const getQuestionText = (props, index) => {
    console.log(props)
    const questions = props.dQuestionList;
    const listItems = questions.map((q) =>
    q.questionText.toString()
    );    

    const listAnswersProto = questions.map((q) =>
    q.answers.split(",")
    );

    var listAnswers = listAnswersProto[index]
    if (listAnswers !== undefined) {
    answer1 = listAnswers[0]
    if (listAnswers.length > 1)
        answer2 = listAnswers[1]
    if (listAnswers.length > 2)
        answer3 = listAnswers[2]
    if (listAnswers.length > 3)
        answer4 = listAnswers[3]
    }

    console.log(index)
    
    if (listItems !== undefined) {
    
    return listItems[index]
    } else {
        return null
    }
}

const nextQuestion = (props) => {
    if (props !== undefined) {
    index += 1
    getQuestionText(props, index)
    }
}

const DQuestions = ({ classes, ...props }) => {
    const [currentId, setCurrentId] = useState(0)

    useEffect(() => {
        props.fetchAlldQuestions()
    }, [])//componentDidMount
    
    return (
        <Paper className={classes.paper} elevation={3}>
            <Grid container>
                <Grid item xs={6}>
                    <DQuestionForm {...({ currentId, setCurrentId })} />
                </Grid>
                <Grid item xs={6}>
                    <TextField fullWidth="true"
                        value={getQuestionText(props, index) || ''} >
                    </TextField>
                    <br></br>
                    <br></br>
                    <Checkbox ></Checkbox>
                    <TextField value={answer1}></TextField>
                    <br></br>
                    <Checkbox ></Checkbox>
                    <TextField value={answer2}></TextField>
                    <br></br>
                    <Checkbox ></Checkbox>
                    <TextField value={answer3}></TextField>
                    <br></br>                    
                    <Checkbox ></Checkbox>
                    <TextField value={answer4}></TextField>
                    <br></br>
                    <br></br>
                    <Button
                            variant="contained"
                            className={classes.smMargin}
                            onClick={nextQuestion(props)}
                        >
                            Next
                        </Button>
                </Grid>
            </Grid>
        </Paper>
    );
}

const mapStateToProps = state => ({
    dQuestionList: state.dQuestion.list
})

const mapActionToProps = {
    fetchAlldQuestions: actions.fetchAll
}

export default connect(mapStateToProps, mapActionToProps)(withStyles(styles)(DQuestions));