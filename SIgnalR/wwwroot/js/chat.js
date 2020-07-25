class Message {
    constructor(username, text, when) {
        this.fromUser = username;
        this.text = text;
        this.sendAt = when;
        this.to = username;
    }
}

// userName is declared in razor page.
const username = userName;
const textInput = document.getElementById('messageText');
//const whenInput = document.getElementById('when');
//const chat = document.getElementById('chat');
const messagesQueue = [];

document.getElementById('submitButton').addEventListener('click', (e) => {
    var currentdate = new Date();
    //when.innerHTML =
    //    (currentdate.getMonth() + 1) + "/"
    //    + currentdate.getDate() + "/"
    //    + currentdate.getFullYear() + " "
    //    + currentdate.toLocaleString('en-US', { hour: 'numeric', minute: 'numeric', hour12: true })
});

function clearInputField() {
    messagesQueue.push(textInput.value);
    textInput.value = "";
}

function sendMessage() {
    let text = messagesQueue.shift() || "";
    if (text.trim() === "") return;
    
    let when = new Date();
    let message = new Message(username, text);
    sendMessageToHub(message);
}

function addMessageToChat(message) {
    let isCurrentUserMessage = message.fromUser === username;
    var nameSpan = document.createElement('span');
    nameSpan.className = 'name';
    nameSpan.textContent = message.fromUser;

    var timeSpan = document.createElement('span');
    timeSpan.className = 'time';
    //var friendlyTime = moment(message.sendAt).format('H:mm');
    timeSpan.textContent = message.sendAt;

    var headerDiv = document.createElement('div');
    headerDiv.appendChild(nameSpan);
    headerDiv.appendChild(timeSpan);

    var messageDiv = document.createElement('div');
    messageDiv.className = 'message';
    messageDiv.textContent = message.text;

    var newItem = document.createElement('li');
    newItem.appendChild(headerDiv);
    newItem.appendChild(messageDiv);

    var chatHistoryEl = document.getElementById('chatHistory');
    chatHistoryEl.appendChild(newItem);
    chatHistoryEl.scrollTop = chatHistoryEl.scrollHeight - chatHistoryEl.clientHeight;
}
