function getNextGen(paramObj) {
    return postWithParams("http://localhost:5000/Services/api/GetNextSimulation", paramObj);
}