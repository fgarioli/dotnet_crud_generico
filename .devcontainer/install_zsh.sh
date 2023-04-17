#!/bin/bash

DEFAULT_THEME=${1:-"robbyrussell"}

# Instalação do Oh My Zsh
sh -c "$(curl -fsSL https://raw.githubusercontent.com/ohmyzsh/ohmyzsh/master/tools/install.sh)"

sudo chsh -s $(which zsh) $(whoami)

# Instalação do tema Spaceship
git clone https://github.com/denysdovhan/spaceship-prompt.git "$HOME/.oh-my-zsh/custom/themes/spaceship-prompt"

# Criação de um link simbólico para o tema Spaceship
ln -s "$HOME/.oh-my-zsh/custom/themes/spaceship-prompt/spaceship.zsh-theme" "$HOME/.oh-my-zsh/custom/themes/spaceship.zsh-theme"

# Configuração do tema Spaceship no arquivo .zshrc
sed -i "s/ZSH_THEME=\"$DEFAULT_THEME\"/ZSH_THEME=\"spaceship\"/g" ~/.zshrc

# Instalação do plugin Spaceship Vi Mode
git clone https://github.com/spaceship-prompt/spaceship-vi-mode.git $HOME/.oh-my-zsh/custom/plugins/spaceship-vi-mode

# Configuração do plugin Spaceship Vi Mode no arquivo .zshrc
sed -i 's/plugins=(git)/plugins=(git spaceship-vi-mode)/g' ~/.zshrc

echo "
SPACESHIP_PROMPT_ORDER=(
  user          # Username section
  dir           # Current directory section
  host          # Hostname section
  git           # Git section (git_branch + git_status)
  hg            # Mercurial section (hg_branch  + hg_status)
  exec_time     # Execution time
  line_sep      # Line break
  vi_mode       # Vi-mode indicator
  jobs          # Background jobs indicator
  exit_code     # Exit code section
  char          # Prompt character
)
SPACESHIP_USER_SHOW=always
SPACESHIP_PROMPT_ADD_NEWLINE=false
SPACESHIP_CHAR_SYMBOL=\"❯\"
SPACESHIP_CHAR_SUFFIX=\" \"" >> ~/.zshrc

# Instala o plugin zinit
zsh -c "$(curl -fsSL https://raw.githubusercontent.com/zdharma-continuum/zinit/HEAD/scripts/install.sh)"

echo "
zinit light zdharma-continuum/fast-syntax-highlighting
zinit light zsh-users/zsh-autosuggestions
zinit light zsh-users/zsh-completions" >> ~/.zshrc
