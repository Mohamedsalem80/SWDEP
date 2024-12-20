import random
import json 
import pickle
import numpy as np
import spacy
import os
import sys
import tensorflow as tf
import logging
from tensorflow.keras.models import load_model

# Suppress TensorFlow warnings and logs
os.environ['TF_CPP_MIN_LOG_LEVEL'] = '3'  # Suppress all logs (Error only)
logging.getLogger('tensorflow').setLevel(logging.ERROR)
tf.get_logger().setLevel('ERROR')

# Load pre-trained data
intents = json.loads(open('intents.json').read())
words  = pickle.load(open('words.pkl', 'rb'))
classes = pickle.load(open('classes.pkl', 'rb')) 
model = load_model('Chatbot_model.h5')

# Load spaCy English model
nlp = spacy.load("en_core_web_sm")

# Tokenize and lemmatize the sentence using spaCy
def clean_sentence(sentence):
    doc = nlp(sentence)
    sentence_words = [token.lemma_ for token in doc if token.is_alpha]
    return sentence_words

# Convert sentence into a bag of words
def bag_of_words(sentence):
    sentence_words = clean_sentence(sentence)
    bag = [0] * len(words)
    for w in sentence_words:
        for i, word in enumerate(words):
            if word == w:
                bag[i] = 1
    return np.array(bag)

# Predict the intent of the sentence
def predict_class(sentence):
    bow = bag_of_words(sentence)
    res = model.predict(np.array([bow]))[0]
    ERROR_THRESHOLD = 0.25
    results = [[i, r] for i, r in enumerate(res) if r > ERROR_THRESHOLD]
    results.sort(key=lambda x: x[1], reverse=True)
    return_list = []
    for r in results:
        return_list.append({'intent': classes[r[0]], 'probability': str(r[1])})
    return return_list

# Get the response for the predicted intent
def get_response(intent_list, intent_json):
    tag = intent_list[0]['intent']
    list_of_intents = intent_json['intents']
    for intent in list_of_intents:
        if intent['tag'] == tag:
            result = random.choice(intent['responses'])
            break
    return result  # Return a simple string

# Main loop for interacting with the chatbot
message = ""
for i in range(1, len(sys.argv)):
    message += " " + sys.argv[i]
message = message.strip()
print(f"Received message: {message}")  # Debugging line to see the input
ints = predict_class(message)
res = get_response(ints, intents)

print(f"Response: {res}")  # Print the response for debugging

with open("question.txt", "w") as file:
    file.write(message)  # Write the response to the file

with open("response.txt", "w") as file:
    file.write(res)  # Write the response to the file