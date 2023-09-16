import random

# List of words to choose from
word_list = ["apple", "banana", "cherry", "date", "elderberry", "fig", "grape", "honeydew", "kiwi", "lemon"]

# Generate a random sentence of 5 words
sentence = " ".join(random.choice(word_list) for _ in range(5))

# Define the filename
filename = "X.txt"

# Open the file in append mode and save the sentence
with open(filename, "a") as file:
    file.write(sentence + "\n")

# Print the generated sentence for reference
print(f"Generated Sentence: {sentence}")